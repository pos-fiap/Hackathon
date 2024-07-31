using Hackathon.Api.Authorize;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Api.Controllers
{
    [CustomAuthorization]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }


        [HttpPost("AssignRoleUser")]
        public async Task<IActionResult> AssignRoleToUser(UserRoleDto userRoleDto)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _userRoleService.AssignRoleToUser(userRoleDto)) : CustomResponse(ModelState);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        [HttpGet("GetRolesByUser")]
        public async Task<IActionResult> GetRolesByUser(int userId)
        {
            try
            {
                return ModelState.IsValid ? Ok(await _userRoleService.GetByUser(userId)) : CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }
    }
}
