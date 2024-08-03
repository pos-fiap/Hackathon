using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hackathon.Api.Controllers
{
    //[CustomAuthorization]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        [HttpGet("doctor-availability")]
        [ProducesResponseType(typeof(BaseOutput<Doctor>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDoctorAvailability(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _appointmentService.GetDoctorAvailability(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet("available-doctors")]
        [ProducesResponseType(typeof(BaseOutput<List<Doctor>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _doctorService.GetAllLimited()) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseOutput<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(AppointmentDto appointment)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _appointmentService.Create(appointment)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _appointmentService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }
        }
    }
}
