using AutoMapper;
using FluentValidation;
using Hackathon.Application.BaseResponse;
using Hackathon.Application.DTOs;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Models;
using Hackathon.Application.Utils;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces;

namespace Hackathon.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginDto> _loginDtoValidator;
        private readonly IValidator<UserDto> _userDtoValidator;
        private readonly IValidator<UserUpdateDto> _userUpdateDtoValidator;

        public UserService(IUserRepository userRepository,
                           IPersonRepository personRepository,
                           IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IValidator<UserDto> userDtoValidator,
                           IValidator<LoginDto> loginDtoValidator,
                           IValidator<UserUpdateDto> userUpdateDtoValidator)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userDtoValidator = userDtoValidator;
            _loginDtoValidator = loginDtoValidator;
            _userUpdateDtoValidator = userUpdateDtoValidator;
        }

        public async Task<BaseOutput<List<User>>> Get()
        {
            BaseOutput<List<User>> response = new();

            IEnumerable<User> users = await _userRepository.GetAsync();

            response.Response = users.ToList();

            return response;
        }
        public async Task<BaseOutput<User>> Get(int Id)
        {
            User user = await _userRepository.GetAsync(Id);

            BaseOutput<User> response = new()
            {
                Response = user
            };

            return response;
        }

        public async Task<BaseOutput<User>> Get(LoginDto loginDto)
        {
            BaseOutput<User> response = new();

            var validationResult = _loginDtoValidator.Validate(loginDto);
            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(x => response.AddError(x.ErrorMessage));
                return response;
            }

            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Email == loginDto.Username, true);

            response.Response = users.FirstOrDefault() ?? new User();
            return response;
        }


        public async Task<BaseOutput<User>> Get(UserDto userDto)
        {
            IEnumerable<User> users = await _userRepository.GetAsync(x => x.Email == userDto.Username, true);

            BaseOutput<User> response = new()
            {
                IsSuccessful = users.Any(),
                Response = users?.FirstOrDefault() ?? new User()
            };

            return response;
        }

        public async Task<BaseOutput<int>> Create(UserDto userDto)
        {

            BaseOutput<int> response = new();

            ValidationUtil.ValidateClass(userDto, _userDtoValidator, response);

            IList<Person> person = _personRepository.GetPersonByDocument(userDto.PersonalInformations.CPF);

            if (person.Any())
            {
                response.AddError($"There is an active person with the document provided (Name: {person.First().Name}), please reuse it to register.");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User userMapped = _mapper.Map<User>(userDto);

            await _userRepository.AddAsync(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped.Id;

            return response;
        }

        public async Task<BaseOutput<User>> Update(UserUpdateDto userDto)
        {
            BaseOutput<User> response = new();

            User user = await _userRepository.GetSingleAsync(x => x.Id == userDto.Id, true);

            ValidationUtil.ValidateClass(userDto, _userUpdateDtoValidator, response);

            if (user is null)
            {
                response.AddError("Not Found!");
            }

            if (response.Errors.Any())
            {
                return response;
            }

            User userMapped = _mapper.Map<User>(userDto);
            userMapped.PersonId = user.PersonId;

            _userRepository.Update(userMapped);
            await _unitOfWork.CommitAsync();

            response.Response = userMapped;

            return response;
        }

        public async Task<BaseOutput<bool>> Delete(int Id)
        {
            BaseOutput<bool> response = new();

            User user = new() { Id = Id };

            if (!await Verify(user.Id))
            {
                response.AddError("Not Found");
            }

            _userRepository.Delete(user);
            await _unitOfWork.CommitAsync();

            response.Response = true;

            return response;
        }

        public async Task<bool> Verify(string username)
        {
            return await _userRepository.ExistsAsync(x => x.Email == username);
        }

        public async Task<bool> Verify(int Id)
        {
            return await _userRepository.ExistsAsync(x => x.Id == Id);
        }

        public async Task UpdateUserRefreshToken(User user, RefreshTokenModel tokenModel)
        {
            user.RefreshToken = tokenModel.RefreshToken;
            user.RefreshTokenExpiryDate = tokenModel.ExpirationDate;
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();
        }

        public Task<User> Get(string username)
        {
            return _userRepository.GetSingleAsync(x => x.Email == username, true);
        }

    }
}
