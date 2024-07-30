using AutoMapper;
using FluentValidation;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Utils;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;

namespace Hackathon.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserRoleDto> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository,
                               IUserRepository userRepository,
                               IValidator<UserRoleDto> validator,
                               IUnitOfWork unitOfWork,
                               IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseOutput<int>> AssignRoleToUser(UserRoleDto userRoleDto)
        {

            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(userRoleDto, _validator, response);

            if (!await _userRepository.ExistsAsync(exp => exp.Id == userRoleDto.UserId))
            {
                response.AddError("Id de usuário não econtrado!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            //TODO: ACRESCENTAR VALIDAÇÃO DE EXISTÊNCIA DO ID DA ROLE

            IEnumerable<UserRole> actualRole = await _userRoleRepository.GetAsync(x => x.UserId == userRoleDto.UserId, true);

            var userRoleMapped = _mapper.Map<IEnumerable<UserRole>>(userRoleDto);

            IEnumerable<UserRole> includedRoles = userRoleMapped.Where(x => !actualRole.Select(y => y.RoleId).Contains(x.RoleId));

            IEnumerable<UserRole> deletedRoles = actualRole.Where(x => !userRoleMapped.Select(y => y.RoleId).Contains(x.RoleId));

            if (userRoleDto.Roles is null || !userRoleDto.Roles.Any()) { deletedRoles = actualRole; }

            if (deletedRoles.Any()) RemoveDeletedRoles(deletedRoles);

            if (includedRoles.Any()) AddIncludedRoles(includedRoles);

            await _unitOfWork.CommitAsync();

            response.Response = 0;

            return response;
        }

        public async Task<BaseOutput<IList<UserRole>>> GetByUser(int user)
        {
            BaseOutput<IList<UserRole>> response = new();

            if (!await _userRepository.ExistsAsync(exp => exp.Id == user))
            {
                response.AddError("Id de usuário não econtrado!");
                return response;
            }

            response.Response = (await _userRoleRepository.GetAsync(x => x.UserId == user, true)).ToList();

            return response;
        }

        public async Task<UserRole> GetRoleByUsername(string username)
        {
            return await _userRoleRepository.GetRoleByUsername(username);
        }

        private async void AddIncludedRoles(IEnumerable<UserRole> userRoles)
        {
            await _userRoleRepository.AddAsync(userRoles.ToList());
        }

        private void RemoveDeletedRoles(IEnumerable<UserRole> userRoles)
        {
            _userRoleRepository.Delete(userRoles.ToList());
        }


    }
}
