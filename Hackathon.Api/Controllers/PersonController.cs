﻿using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hackathon.Api.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<Person>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<Person>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return CustomResponse(await _personService.Get());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseOutput<Person>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<Person>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] PersonUpdateDTO personDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _personService.Update(personDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

    }
}
