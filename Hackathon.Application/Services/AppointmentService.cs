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
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IDefaultAvailabilityRepository _defaultAvailabilityRepository;
        private readonly ISpecificAvailabilityRepository _specificAvailabilityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AppointmentDto> _appointmentDtoValidator;

        public AppointmentService(IAppointmentRepository appointmentRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<AppointmentDto> appointmentDtoValidator,
                           IDefaultAvailabilityRepository defaultAvailabilityRepository,
                           ISpecificAvailabilityRepository specificAvailabilityRepository)
        {
            _appointmentRepository = appointmentRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentDtoValidator = appointmentDtoValidator;
            _defaultAvailabilityRepository = defaultAvailabilityRepository;
            _specificAvailabilityRepository = specificAvailabilityRepository;
        }

        public async Task<BaseOutput<int>> Create(AppointmentDto appointmentDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(appointmentDto, _appointmentDtoValidator, response);

            var defaultAvailability = await _defaultAvailabilityRepository.GetSingleAsync(x => x.DoctorId == appointmentDto.DoctorId, true);

            if (defaultAvailability == null)
            {
                throw new Exception("DefaultAvailability's default availability not found.");
            }

            var dayOfWeek = appointmentDto.AppointmentDate.DayOfWeek;
            TimeSpan? startTime, endTime, lunchStart, lunchEnd;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    startTime = defaultAvailability.StartMonday;
                    endTime = defaultAvailability.EndMonday;
                    lunchStart = defaultAvailability.LunchStartMonday;
                    lunchEnd = defaultAvailability.LunchEndMonday;
                    break;
                case DayOfWeek.Tuesday:
                    startTime = defaultAvailability.StartTuesday;
                    endTime = defaultAvailability.EndTuesday;
                    lunchStart = defaultAvailability.LunchStartTuesday;
                    lunchEnd = defaultAvailability.LunchEndTuesday;
                    break;
                case DayOfWeek.Wednesday:
                    startTime = defaultAvailability.StartWednesday;
                    endTime = defaultAvailability.EndWednesday;
                    lunchStart = defaultAvailability.LunchStartWednesday;
                    lunchEnd = defaultAvailability.LunchEndWednesday;
                    break;
                case DayOfWeek.Thursday:
                    startTime = defaultAvailability.StartThursday;
                    endTime = defaultAvailability.EndThursday;
                    lunchStart = defaultAvailability.LunchStartThursday;
                    lunchEnd = defaultAvailability.LunchEndThursday;
                    break;
                case DayOfWeek.Friday:
                    startTime = defaultAvailability.StartFriday;
                    endTime = defaultAvailability.EndFriday;
                    lunchStart = defaultAvailability.LunchStartFriday;
                    lunchEnd = defaultAvailability.LunchEndFriday;
                    break;
                case DayOfWeek.Saturday:
                    startTime = defaultAvailability.StartSaturday;
                    endTime = defaultAvailability.EndSaturday;
                    lunchStart = defaultAvailability.LunchStartSaturday;
                    lunchEnd = defaultAvailability.LunchEndSaturday;
                    break;
                case DayOfWeek.Sunday:
                    startTime = defaultAvailability.StartSunday;
                    endTime = defaultAvailability.EndSunday;
                    lunchStart = defaultAvailability.LunchStartSunday;
                    lunchEnd = defaultAvailability.LunchEndSunday;
                    break;
                default:
                    throw new Exception("Invalid day of the week.");
            }

            if (!startTime.HasValue
                || !endTime.HasValue
                || appointmentDto.StartTime < startTime.Value
                || appointmentDto.EndTime > endTime.Value
                || (appointmentDto.StartTime >= lunchStart && appointmentDto.StartTime < lunchEnd)
                || (appointmentDto.EndTime > lunchStart && appointmentDto.EndTime <= lunchEnd))
            {
                throw new Exception("Appointment time is outside the doctor's working hours.");
            }

            var specificAvailability = await _specificAvailabilityRepository.GetSingleAsync(x => x.DoctorId == appointmentDto.DoctorId && x.Date == appointmentDto.AppointmentDate, true);

            if (specificAvailability != null)
            {
                if (!specificAvailability.IsAvailable ||
                    (specificAvailability.StartTime.HasValue && appointmentDto.StartTime < specificAvailability.StartTime.Value) ||
                    (specificAvailability.EndTime.HasValue && appointmentDto.EndTime > specificAvailability.EndTime.Value))
                {
                    throw new Exception("Appointment time is outside the doctor's specific availability for this date.");
                }
            }

            Appointment appointmentMapped = _mapper.Map<Appointment>(appointmentDto);

            await _appointmentRepository.AddAsync(appointmentMapped);
            await _unitOfWork.CommitAsync();

            response.Response = appointmentMapped.Id;

            return response;
        }

        public async Task<BaseOutput<bool>> Delete(int id)
        {
            BaseOutput<bool> response = new();

            Appointment appointment = await _appointmentRepository.GetSingleAsync(exp => exp.Id == id, true);

            if (appointment is null)
            {
                response.AddError("Appointment not found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            Appointment appointmentMapped = _mapper.Map<Appointment>(appointment);

            _appointmentRepository.Delete(appointmentMapped);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }
    }
}
