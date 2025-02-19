﻿using Hackathon.Application.Interfaces;
using Hackathon.Domain.Interfaces;

namespace Hackathon.Application.Services
{
    public class RoleAccessService : IRoleAccessService
    {
        private readonly IRoleAccessRepository _roleAccessRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleAccessService(IRoleAccessRepository roleAccessRepository, IUnitOfWork unitOfWork)
        {
            _roleAccessRepository = roleAccessRepository;
            _unitOfWork = unitOfWork;

        }

        public bool HasAccess(int roleId, string route)
        {
            return _roleAccessRepository.HasAccess(roleId, route);
        }

    }
}
