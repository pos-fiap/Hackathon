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
        private readonly IValidator<DoctorDto> _doctorDtoValidator;
        private readonly IValidator<PostDoctorDto> _postDoctorDtoValidator;

        public DoctorService(IDoctorRepository doctorRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<DoctorDto> doctorDtoValidator,
                           IValidator<PostDoctorDto> postDoctorDtoValidator)
        {
            _doctorRepository = doctorRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _doctorDtoValidator = doctorDtoValidator;
            _postDoctorDtoValidator = postDoctorDtoValidator;
        }

        public async Task<BaseOutput<List<Doctor>>> Get()
        {
            BaseOutput<List<Doctor>> response = new();

            IEnumerable<Doctor> doctor = await _doctorRepository.GetAsync();

            response.Response = doctor.ToList();

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

            IList<Person> person = _personRepository.GetPersonByDocument(doctorDto.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            IEnumerable<Doctor> doctors = await _doctorRepository.GetAsync(x => x.Person.CPF == doctorDto.PersonalInformations.CPF, true);

            if (doctors.Any())
            {
                response.AddError($"There is an doctor with the CPF provided.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Doctor doctorMapped = _mapper.Map<Doctor>(doctorDto);

            await _doctorRepository.AddAsync(doctorMapped);
            await _unitOfWork.CommitAsync();

            response.Response = doctorMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Update(DoctorDto doctorDto)
        {
            BaseOutput<bool> response = new();

            ValidationUtil.ValidateClass(doctorDto, _doctorDtoValidator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(doctorDto.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            Doctor doctorMapped = _mapper.Map<Doctor>(doctorDto);

            if (!await VerifyUser(doctorMapped.Id))
            {
                response.AddError("Not Found");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _doctorRepository.Update(doctorMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

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
