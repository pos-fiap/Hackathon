using Hackathon.Api.Authorize;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hackathon.Api.Controllers
{
    [CustomAuthorization]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<Doctor>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _doctorService.GetAll()) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<Doctor>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _doctorService.Get(id)) : CustomResponse(ModelState);
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
        public async Task<IActionResult> Post(PostDoctorDto doctor)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _doctorService.Create(doctor)) : CustomResponse(ModelState);
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
        public async Task<IActionResult> Put(PutDoctorDto doctor)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _doctorService.Update(doctor)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        //[HttpPost("SpecificAvailabilities")]
        //[ProducesResponseType(typeof(BaseOutput<int>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> PostSpecificAvailabilities(PostDoctorDto doctor)
        //{
        //    try
        //    {
        //        return ModelState.IsValid ? Ok(await _doctorService.CreateSpecificAvailabilities(doctor)) : CustomResponse(ModelState);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalErrorResponse(ex);
        //    }
        //}

        //[HttpDelete("SpecificAvailabilities")]
        //[ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> DeleteSpecificAvailabilities(int id)
        //{
        //    try
        //    {
        //        return ModelState.IsValid ? Ok(await _doctorService.Delete(id)) : CustomResponse(ModelState);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalErrorResponse(ex);

        //    }
        //}


        //[HttpPut("Availabilities")]
        //[ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> PutAllAvailabilities(PutDoctorDto doctor)
        //{
        //    try
        //    {
        //        return ModelState.IsValid ? Ok(await _doctorService.UpdateAvailabilities(doctor)) : CustomResponse(ModelState);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalErrorResponse(ex);
        //    }
        //}

        [HttpDelete]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _doctorService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }
        }
    }
}
