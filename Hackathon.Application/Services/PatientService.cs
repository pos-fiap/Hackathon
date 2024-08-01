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
        private readonly IValidator<PatientUpdateDTO> _patientUpdateDtoValidator;

        public PatientService(IPatientRepository patientRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<PatientUpdateDTO> patientUpdateDtoValidator,
                           IValidator<PatientDto> patientDtoValidator)
        {
            _patientRepository = patientRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _patientDtoValidator = patientDtoValidator;
            _patientUpdateDtoValidator = patientUpdateDtoValidator;
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


        public async Task<BaseOutput<int>> Create(PatientDto patientDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(patientDto, _patientDtoValidator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(patientDto.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            IEnumerable<Patient> patients = await _patientRepository.GetAsync(x => x.Person.CPF == patientDto.PersonalInformations.CPF, true);

            if (patients.Any())
            {
                response.AddError($"There is an patient with the CPF provided.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Patient patientMapped = _mapper.Map<Patient>(patientDto);

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
