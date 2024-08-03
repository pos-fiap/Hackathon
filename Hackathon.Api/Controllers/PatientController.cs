using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hackathon.Api.Controllers
{
    //[CustomAuthorization]
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<Patient>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _patientService.Get()) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<Patient>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _patientService.Get(id)) : CustomResponse(ModelState);
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
        public async Task<IActionResult> Post(PostPatientDto patient)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _patientService.Create(patient)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(PatientDto patient)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _patientService.Update(patient)) : CustomResponse(ModelState);
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
                return ModelState.IsValid ? Ok(await _patientService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }
        }
    }
}
