using Hackathon.Api.Authorize;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Hackathon.Api.Controllers
{
    [CustomAuthorization]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return CustomResponse(await _userService.Get());
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<List<User>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return CustomResponse(await _userService.Get(Id));
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.Create(userDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<User>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] UserUpdateDto userDto)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.Update(userDto)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<bool>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([NotNull, Range(0, int.MaxValue)] int Id)
        {
            try
            {
                return ModelState.IsValid ? CustomResponse(await _userService.Delete(Id)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
