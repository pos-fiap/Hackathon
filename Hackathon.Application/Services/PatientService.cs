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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<PatientDTO> _patientDtoValidator;
        private readonly IValidator<PatientUpdateDTO> _patientUpdateDtoValidator;

        public PatientService(IPatientRepository patientRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<PatientUpdateDTO> patientUpdateDtoValidator,
                           IValidator<PatientDTO> patientDtoValidator)
        {
            _patientRepository = patientRepository;
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

        public async Task<BaseOutput<Patient>> Get(PatientDTO patientDto)
        {
            BaseOutput<Patient> response = new();

            var validationResult = _patientDtoValidator.Validate(patientDto);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(x => response.AddError(x.ErrorMessage));
                return response;
            }

            IEnumerable<Patient> patient = await _patientRepository.GetAsync(x => x.Name == patientDto.Name, true);

            response.Response = patient.FirstOrDefault() ?? new Patient();
            return response;
        }


        public async Task<BaseOutput<int>> Create(PatientDTO patientDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(patientDto, _patientDtoValidator, response);

            IList<Patient> patient = _patientRepository.GetPatientByDocument(patientDto.Document);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Person personMapped = _mapper.Map<Person>(personDto);

            await _personRepository.AddAsync(personMapped);
            await _unitOfWork.CommitAsync();

            response.Response = personMapped.Id;

            return response;
        }

        public async Task<BaseOutput<Person>> Update(PersonUpdateDTO personDto)
        {
            BaseOutput<Person> response = new();

            ValidationUtil.ValidateClass(personDto, _personUpdateDtoValidator, response);

            Person personMapped = _mapper.Map<Person>(personDto);

            if (!await Verify(personMapped.Id))
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            _personRepository.Update(personMapped);
            await _unitOfWork.CommitAsync();

            response.Response = personMapped;

            return response;
        }

        public async Task<bool> Verify(string name)
        {
            return await _personRepository.ExistsAsync(x => x.Name == name);
        }

        public async Task<bool> Verify(int Id)
        {
            return await _personRepository.ExistsAsync(x => x.Id == Id);
        }



        public Task<Person> Get(string name)
        {
            return _personRepository.GetSingleAsync(x => x.Name == name, true);
        }

    }
}
