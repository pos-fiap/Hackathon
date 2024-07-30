using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Models;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces
{
    public interface IUserService
    {
        Task<BaseOutput<int>> Create(UserDto userDto);
        Task<BaseOutput<User>> Update(UserUpdateDto userDto);
        Task<bool> Verify(string username);
        Task<bool> Verify(int Id);
        Task<BaseOutput<bool>> Delete(int Id);

        Task<BaseOutput<List<User>>> Get();
        Task<BaseOutput<User>> Get(int Id);
        Task<BaseOutput<User>> Get(UserDto userDto);
        Task<User> Get(string username);
        Task<BaseOutput<User>> Get(LoginDto userDto);
        Task UpdateUserRefreshToken(User user, RefreshTokenModel tokenModel);

    }
}