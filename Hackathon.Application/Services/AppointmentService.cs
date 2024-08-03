using AutoMapper;
using FluentValidation;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Utils;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;
using Hackathon.Infra.Messaging.Interfaces;
using Hackathon.Infra.Messaging.Models;

namespace Hackathon.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private const int MaxDays = 90;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IDefaultAvailabilityRepository _defaultAvailabilityRepository;
        private readonly ISpecificAvailabilityRepository _specificAvailabilityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AppointmentDto> _appointmentDtoValidator;
        private readonly IMessaging _messagingService;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<AppointmentDto> appointmentDtoValidator,
                           IDefaultAvailabilityRepository defaultAvailabilityRepository,
                           ISpecificAvailabilityRepository specificAvailabilityRepository,
                           IMessaging messagingService,
                           IDoctorRepository doctorRepository,
                           IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentDtoValidator = appointmentDtoValidator;
            _defaultAvailabilityRepository = defaultAvailabilityRepository;
            _specificAvailabilityRepository = specificAvailabilityRepository;
            _messagingService = messagingService;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public async Task<BaseOutput<List<AvailabilityDto>>> GetDoctorAvailability(int doctorId)
        {
            BaseOutput<List<AvailabilityDto>> response = new();

            var defaultAvailability = await _defaultAvailabilityRepository.GetSingleAsync(x => x.DoctorId == doctorId, true);
            if (defaultAvailability == null)
            {
                response.AddError("Default availability not found for the specified doctor.");
                return response;
            }

            var specificAvailabilities = await _specificAvailabilityRepository.GetAsync(x => x.DoctorId == doctorId && x.IsAvailable, true);
            var appointments = await _appointmentRepository.GetAsync(x => x.DoctorId == doctorId, true);

            List<AvailabilityDto> availabilities = new();
            DateTime today = DateTime.Today;

            void AddDefaultAvailabilityWithLunch(DateTime date, TimeSpan? start, TimeSpan? end, TimeSpan? lunchStart, TimeSpan? lunchEnd)
            {
                if (start.HasValue && end.HasValue)
                {
                    if (lunchStart.HasValue && lunchEnd.HasValue)
                    {
                        if (start < lunchStart)
                        {
                            availabilities.Add(new AvailabilityDto
                            {
                                RawDate = date,
                                Date = date.ToString("D"),
                                StartTime = start,
                                EndTime = lunchStart
                            });
                        }

                        if (lunchEnd < end)
                        {
                            availabilities.Add(new AvailabilityDto
                            {
                                RawDate = date,
                                Date = date.ToString("D"),
                                StartTime = lunchEnd,
                                EndTime = end
                            });
                        }
                    }
                    else
                    {
                        availabilities.Add(new AvailabilityDto
                        {
                            RawDate = date,
                            Date = date.ToString("D"),
                            StartTime = start,
                            EndTime = end
                        });
                    }
                }
            }

            for (int i = 0; i < MaxDays; i++)
            {
                DateTime currentDate = today.AddDays(i);
                var dayOfWeek = currentDate.DayOfWeek;

                switch (dayOfWeek)
                {
                    case DayOfWeek.Monday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartMonday, defaultAvailability.EndMonday, defaultAvailability.LunchStartMonday, defaultAvailability.LunchEndMonday);
                        break;
                    case DayOfWeek.Tuesday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartTuesday, defaultAvailability.EndTuesday, defaultAvailability.LunchStartTuesday, defaultAvailability.LunchEndTuesday);
                        break;
                    case DayOfWeek.Wednesday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartWednesday, defaultAvailability.EndWednesday, defaultAvailability.LunchStartWednesday, defaultAvailability.LunchEndWednesday);
                        break;
                    case DayOfWeek.Thursday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartThursday, defaultAvailability.EndThursday, defaultAvailability.LunchStartThursday, defaultAvailability.LunchEndThursday);
                        break;
                    case DayOfWeek.Friday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartFriday, defaultAvailability.EndFriday, defaultAvailability.LunchStartFriday, defaultAvailability.LunchEndFriday);
                        break;
                    case DayOfWeek.Saturday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartSaturday, defaultAvailability.EndSaturday, defaultAvailability.LunchStartSaturday, defaultAvailability.LunchEndSaturday);
                        break;
                    case DayOfWeek.Sunday:
                        AddDefaultAvailabilityWithLunch(currentDate, defaultAvailability.StartSunday, defaultAvailability.EndSunday, defaultAvailability.LunchStartSunday, defaultAvailability.LunchEndSunday);
                        break;
                    default:
                        throw new Exception("Invalid day of the week.");
                }
            }

            foreach (var specificAvailability in specificAvailabilities)
            {
                var specificAvailabilityDto = new AvailabilityDto
                {
                    RawDate = specificAvailability.Date,
                    Date = specificAvailability.Date.ToString("D"),
                    StartTime = specificAvailability.StartTime,
                    EndTime = specificAvailability.EndTime
                };

                var index = availabilities.FindIndex(a => a.Date == specificAvailabilityDto.Date);

                if (index != -1)
                {
                    availabilities[index] = specificAvailabilityDto;
                }
                else
                {
                    availabilities.Add(specificAvailabilityDto);
                }
            }

            foreach (var appointment in appointments)
            {
                var dayOfWeek = appointment.AppointmentDate.DayOfWeek;
                var rawDate = appointment.AppointmentDate.Date;
                var appointmentDate = appointment.AppointmentDate.ToString("D");

                var availability = availabilities.FirstOrDefault(a => a.Date == appointmentDate);

                if (availability != null)
                {
                    var appointmentStart = appointment.StartTime;
                    var appointmentEnd = appointment.EndTime;

                    if (appointmentStart > availability.StartTime && appointmentEnd < availability.EndTime)
                    {
                        if (appointmentStart >= availability.StartTime && appointmentEnd <= availability.EndTime)
                        {
                            continue;
                        }

                        availabilities.Add(new AvailabilityDto
                        {
                            RawDate = rawDate,
                            Date = appointmentDate,
                            StartTime = appointmentEnd,
                            EndTime = availability.EndTime
                        });
                        availability.EndTime = appointmentStart;
                    }
                    else if (appointmentStart <= availability.StartTime && appointmentEnd >= availability.EndTime)
                    {
                        availabilities.Remove(availability);
                    }
                    else if (appointmentStart <= availability.StartTime)
                    {
                        availability.StartTime = appointmentEnd;
                    }
                    else if (appointmentEnd >= availability.EndTime)
                    {
                        availability.EndTime = appointmentStart;
                    }
                }
            }

            availabilities = availabilities.Where(a => a.StartTime < a.EndTime).OrderBy(x => x.RawDate).ThenBy(x => x.StartTime).ToList();

            response.Response = availabilities;
            return response;
        }

        public async Task<BaseOutput<int>> Create(AppointmentDto appointmentDto)
        {
            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(appointmentDto, _appointmentDtoValidator, response);

            if (response.Errors.Any())
            {
                return response;
            }

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

            var specificAvailability = await _specificAvailabilityRepository.GetSingleAsync(x => x.DoctorId == appointmentDto.DoctorId && x.Date == appointmentDto.AppointmentDate, true);

            if ((!startTime.HasValue
                || !endTime.HasValue
                || appointmentDto.StartTime < startTime.Value
                || appointmentDto.EndTime > endTime.Value
                || (appointmentDto.StartTime >= lunchStart && appointmentDto.StartTime < lunchEnd)
                || (appointmentDto.EndTime > lunchStart && appointmentDto.EndTime <= lunchEnd)) && specificAvailability == null)
            {
                throw new Exception("Appointment time is outside the doctor's working hours.");
            }

            if (specificAvailability != null)
            {
                if (!specificAvailability.IsAvailable ||
                    (specificAvailability.StartTime.HasValue && appointmentDto.StartTime < specificAvailability.StartTime.Value) ||
                    (specificAvailability.EndTime.HasValue && appointmentDto.EndTime > specificAvailability.EndTime.Value))
                {
                    throw new Exception("Appointment time is outside the doctor's specific availability for this date.");
                }
            }

            var appointments = await _appointmentRepository.GetAsync(x => x.DoctorId == appointmentDto.DoctorId && x.AppointmentDate == appointmentDto.AppointmentDate, true);

            foreach (var appointment in appointments)
            {
                if (appointmentDto.StartTime >= appointment.StartTime && appointmentDto.StartTime < appointment.EndTime)
                {
                    throw new Exception("There is already an appointment scheduled for this time.");
                }

                if (appointmentDto.EndTime > appointment.StartTime && appointmentDto.EndTime <= appointment.EndTime)
                {
                    throw new Exception("There is already an appointment scheduled for this time.");
                }
            }

            Appointment appointmentMapped = _mapper.Map<Appointment>(appointmentDto);

            await _appointmentRepository.AddAsync(appointmentMapped);
            await _unitOfWork.CommitAsync();

            response.Response = appointmentMapped.Id;

            var doctor = await _doctorRepository.GetSingleAsync(exp => exp.Id == appointmentDto.DoctorId, false);

            var docEmail = doctor?.Person?.User?.Email;

            var patient = await _patientRepository.GetSingleAsync(exp => exp.Id == appointmentDto.PatientId, false);

            await _messagingService.SendMail(new EmailMessage { Subject = "Health&Med - Nova consulta agendada", Message = $"Olá, Dr. {doctor.Person.Name} Você tem uma nova consulta marcada! \r\nPaciente: {patient.Person.Name}. \r\nData e horário: {appointmentMapped.AppointmentDate.Date.ToString("dd/MM/yyyy")} {appointmentMapped.StartTime} às {appointmentMapped.EndTime} .", From = docEmail, To = docEmail });

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
