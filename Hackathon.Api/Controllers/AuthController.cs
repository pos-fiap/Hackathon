﻿using Hackathon.Api.Authorize;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Models;
using Hackathon.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hackathon.Api.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(BaseOutput<TokenDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseOutput<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                BaseOutput<User> userResponse = await _userService.Get(loginDto);
                if (!userResponse.IsSuccessful)
                {
                    return CustomResponse(userResponse);
                }

                BaseOutput<string> validateResponse = _authService.ValidateLogin(userResponse.Response, loginDto);
                if (!validateResponse.IsSuccessful)
                {
                    return CustomResponse(validateResponse);
                }

                string token = _authService.GenerateJwtToken(userResponse.Response);
                RefreshTokenModel refreshToken = _authService.GenerateRefreshToken();

                await _userService.UpdateUserRefreshToken(userResponse.Response, refreshToken);

                TokenDto tokenDto = new()
                {
                    Token = token,
                    RefreshToken = refreshToken.RefreshToken
                };

                return Ok(new BaseOutput<TokenDto>(tokenDto));
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        //[HttpPost("refresh")]
        //[CustomAuthorization(CheckAction = true)]
        //public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        //{
        //    try
        //    {
        //        BaseOutput<TokenDto> response = await _authService.RefreshExpiratedTokenAsync(tokenDto);

        //        if (!response.IsSuccessful)
        //        {
        //            return CustomResponse(response);
        //        }

        //        return Ok(response.Response);

        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalErrorResponse(ex);
        //    }
        //}

    }
}
