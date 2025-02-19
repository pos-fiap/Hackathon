﻿using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IRoleService
    {
        Task<BaseOutput<List<Role>>> Get();
        Task<BaseOutput<Role>> Get(int Id);
        Task<BaseOutput<Role>> Get(RoleDto roleDto);
        Task<BaseOutput<int>> Create(RoleDto roleDto);
        Task<BaseOutput<Role>> Update(RoleUpdateDto roleDto);
        Task<List<int>> VerifyList(List<int> ListId);
        Task<bool> Verify(string rolename);
        Task<bool> Verify(int Id);
        Task<BaseOutput<bool>> Delete(int Id);

    }
}