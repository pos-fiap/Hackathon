﻿using Hackathon.Api.Authorize;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Api.Controllers
{
    [CustomAuthorization]
    public class ValetController : BaseController
    {
        private readonly IValetService _valetService;

        public ValetController(IValetService valetService)
        {
            _valetService = valetService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Get()) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Get(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ValetDto valet)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Create(valet)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(ValetDto valet)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Update(valet)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _valetService.Delete(id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);

            }
        }
    }
}
