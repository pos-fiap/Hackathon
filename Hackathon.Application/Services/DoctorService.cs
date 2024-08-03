using AutoMapper;
using FluentValidation;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Utils;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;

namespace Hackathon.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PutDoctorDto> _doctorDtoValidator;
        private readonly IValidator<PostDoctorDto> _postDoctorDtoValidator;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IDefaultAvailabilityRepository _defaultAvailabilityRepository;

        public DoctorService(IDoctorRepository doctorRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<PutDoctorDto> doctorDtoValidator,
                           IValidator<PostDoctorDto> postDoctorDtoValidator,
                           IUserRepository userRepository,
                           IUserRoleRepository userRoleRepository,
                           IDefaultAvailabilityRepository defaultAvailabilityRepository)
        {
            _doctorRepository = doctorRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _doctorDtoValidator = doctorDtoValidator;
            _postDoctorDtoValidator = postDoctorDtoValidator;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _defaultAvailabilityRepository = defaultAvailabilityRepository;
        }

        public async Task<BaseOutput<List<Doctor>>> GetAll()
        {
            BaseOutput<List<Doctor>> response = new();

            IEnumerable<Doctor> doctor = await _doctorRepository.GetAsync();

            response.Response = doctor.ToList();

            return response;
        }

        public async Task<BaseOutput<List<DoctorDto>>> GetAllLimited()
        {
            BaseOutput<List<DoctorDto>> response = new();

            IEnumerable<Doctor> doctor = await _doctorRepository.GetAsync();

            response.Response = _mapper.Map<List<DoctorDto>>(doctor.ToList());

            return response;
        }

        public async Task<BaseOutput<Doctor>> Get(int Id)
        {
            Doctor doctor = await _doctorRepository.GetAsync(Id);

            BaseOutput<Doctor> response = new()
            {
                Response = doctor
            };

            return response;
        }


        public async Task<BaseOutput<int>> Create(PostDoctorDto doctorDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(doctorDto, _postDoctorDtoValidator, response);

            doctorDto.User.Password = BCrypt.Net.BCrypt.HashPassword(doctorDto.User.Password);

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Email == doctorDto.User.Email, true);

            if (users.Any())
            {
                response.AddError("There is an user with the email provided.");
            }

            IList<Person> person = _personRepository.GetPersonByDocument(doctorDto.User.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            IEnumerable<Doctor> doctors = await _doctorRepository.GetAsync(x => x.Person.CPF == doctorDto.User.PersonalInformations.CPF || x.CRM == doctorDto.CRM, true);

            if (doctors.Any())
            {
                response.AddError($"There is an doctor with the CPF provided.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            var personMapped = _mapper.Map<Person>(doctorDto.User.PersonalInformations);
            await _personRepository.AddAsync(personMapped);
            await _unitOfWork.CommitAsync();

            var userMapped = _mapper.Map<User>(doctorDto.User);
            userMapped.PersonId = personMapped.Id;
            await _userRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();

            var userRole = new UserRole
            {
                UserId = userMapped.Id,
                RoleId = 1 //Doctor
            };

            await _userRoleRepository.AddAsync(userRole);
            await _unitOfWork.CommitAsync();

            Doctor doctorMapped = _mapper.Map<Doctor>(doctorDto);
            doctorMapped.DefaultAvailability = null;
            doctorMapped.PersonId = personMapped.Id;

            await _doctorRepository.AddAsync(doctorMapped);
            await _unitOfWork.CommitAsync();

            var defaultMapped = _mapper.Map<DefaultAvailability>(doctorDto.DefaultAvailability);

            defaultMapped.DoctorId = doctorMapped.Id;

            await _defaultAvailabilityRepository.AddAsync(defaultMapped);
            await _unitOfWork.CommitAsync();

            response.Response = doctorMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(PutDoctorDto doctorDto)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(doctorDto, _doctorDtoValidator, response);

            doctorDto.User.Password = BCrypt.Net.BCrypt.HashPassword(doctorDto.User.Password);

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Email == doctorDto.User.Email && doctorDto.User.Id != x.Id, true);

            if (users.Any())
            {
                response.AddError("There is an user with the email provided.");
            }

            IEnumerable<Person> person = await _personRepository.GetAsync(x => x.CPF == doctorDto.User.PersonalInformations.CPF && x.Id != doctorDto.User.PersonalInformations.Id ,true);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            IEnumerable<Doctor> doctors = await _doctorRepository.GetAsync(x => x.CRM == doctorDto.CRM && x.Id != doctorDto.Id , true);

            if (doctors.Any())
            {
                response.AddError($"There is an doctor with the CPF provided.");
            }

            Doctor doctorMapped = _mapper.Map<Doctor>(doctorDto);

            if (!await VerifyUser(doctorMapped.Id))
            {
                response.AddError("Doctor Not Found");
            }

            if (!await _userRepository.ExistsAsync(x => x.Id == doctorDto.User.Id))
            {
                response.AddError("User Not Found");
            }

            if (!await _userRepository.ExistsAsync(x => x.Id == doctorDto.User.PersonalInformations.Id))
            {
                response.AddError("Person Not Found");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            var personMapped = _mapper.Map<Person>(doctorDto.User.PersonalInformations);
            _personRepository.Update(personMapped);
            await _unitOfWork.CommitAsync();

            var userMapped = _mapper.Map<User>(doctorDto.User);
            userMapped.PersonId = personMapped.Id;
            _userRepository.Update(userMapped);
            await _unitOfWork.CommitAsync();

            _doctorRepository.Update(doctorMapped);
            await _unitOfWork.CommitAsync();

            var defaultMapped = _mapper.Map<DefaultAvailability>(doctorDto.DefaultAvailability);

            defaultMapped.DoctorId = doctorMapped.Id;

            _defaultAvailabilityRepository.Update(defaultMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            if (id == 1)
            {
                response.AddError("You can't delete the admin user.");
                return response;
            }

            Doctor doctor = await _doctorRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (doctor is null)
            {
                response.AddError("Doctor not found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Doctor doctorMapped = _mapper.Map<Doctor>(doctor);

            _doctorRepository.Delete(doctorMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }
        public async Task<bool> VerifyUser(int Id)
        {
            return await _doctorRepository.ExistsAsync(x => x.Id == Id);
        }

    }
}
