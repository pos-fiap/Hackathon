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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PatientDto> _patientDtoValidator;
        private readonly IValidator<PostPatientDto> _postPatientDtoValidator;
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public PatientService(IPatientRepository patientRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<PatientDto> patientDtoValidator,
                           IValidator<PostPatientDto> postPatientDtoValidator,
                           IUserRepository userRepository,
                           IUserRoleRepository userRoleRepository)
        {
            _patientRepository = patientRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _patientDtoValidator = patientDtoValidator;
            _postPatientDtoValidator = postPatientDtoValidator;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public PatientService()
        {
        }

        public async Task<BaseOutput<List<Patient>>> Get()
        {
            BaseOutput<List<Patient>> response = new();

            IEnumerable<Patient> patient = await _patientRepository.GetAsync();

            response.Response = patient.ToList();

            return response;
        }
        public async Task<BaseOutput<Patient>> Get(int Id)
        {
            Patient patient = await _patientRepository.GetAsync(Id);

            BaseOutput<Patient> response = new()
            {
                Response = patient
            };

            return response;
        }


        public async Task<BaseOutput<int>> Create(PostPatientDto patientDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(patientDto, _postPatientDtoValidator, response);

            patientDto.User.Password = BCrypt.Net.BCrypt.HashPassword(patientDto.User.Password);

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Email == patientDto.User.Email, true);

            if (users.Any())
            {
                response.AddError("There is an user with the email provided.");
            }

            IList<Person> person = _personRepository.GetPersonByDocument(patientDto.User.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            IEnumerable<Patient> patients = await _patientRepository.GetAsync(x => x.Person.CPF == patientDto.User.PersonalInformations.CPF, true);

            if (patients.Any())
            {
                response.AddError($"There is an patient with the CPF provided.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            var personMapped = _mapper.Map<Person>(patientDto.User.PersonalInformations);
            await _personRepository.AddAsync(personMapped);
            await _unitOfWork.CommitAsync();

            var userMapped = _mapper.Map<User>(patientDto.User);
            userMapped.PersonId = personMapped.Id;
            await _userRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();

            var userRole = new UserRole
            {
                UserId = userMapped.Id,
                RoleId = 2 //Patient
            };

            await _userRoleRepository.AddAsync(userRole);
            await _unitOfWork.CommitAsync();

            Patient patientMapped = _mapper.Map<Patient>(patientDto);
            patientMapped.PersonId = personMapped.Id;

            await _patientRepository.AddAsync(patientMapped);
            await _unitOfWork.CommitAsync();

            response.Response = patientMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(PatientDto patientDto)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(patientDto, _patientDtoValidator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(patientDto.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            Patient patientMapped = _mapper.Map<Patient>(patientDto);

            if (!await VerifyUser(patientMapped.Id))
            {
                response.AddError("Not Found");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _patientRepository.Update(patientMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Patient patient = await _patientRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (patient is null)
            {
                response.AddError("Patient not found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Patient patientMapped = _mapper.Map<Patient>(patient);

            _patientRepository.Delete(patientMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }
        public async Task<bool> VerifyUser(int Id)
        {
            return await _patientRepository.ExistsAsync(x => x.Id == Id);
        }

    }
}
