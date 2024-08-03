using Hackathon.Application.BaseResponse;
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

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
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
