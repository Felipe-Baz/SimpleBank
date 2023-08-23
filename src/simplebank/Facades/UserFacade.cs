using AutoMapper;
using simplebank.Facades.interfaces;
using simplebank.Model;
using simplebank.Services.Interfaces;

namespace simplebank.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserFacade(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> DeleteAsync(int id)
        {
            var result =  await _userService.DeleteAsync(id: id);
            var resultMapped = _mapper.Map<UserResponseDTO>(result);
            return resultMapped;
        }

        public async Task<UserResponseDTO> DetailsAsync(int id)
        {
            var result =  await _userService.DetailsAsync(id: id);
            var resultMapped = _mapper.Map<UserResponseDTO>(result);
            return resultMapped;
        }

        public async Task<List<UserResponseDTO>> ListAsync()
        {
            var result =  await _userService.ListAsync();
            var resultMapped = _mapper.Map<List<UserResponseDTO>>(result);
            return resultMapped;
        }

        public async Task<UserResponseDTO> UpdateAsync(UserUpdateDTO user)
        {
            var userMapped = _mapper.Map<User>(user);
            var result =  await _userService.UpdateAsync(user: userMapped);
            var resultMapped = _mapper.Map<UserResponseDTO>(result);
            return resultMapped;
        }

        public async Task<UserResponseDTO> CreateAsync(UserCreateDTO user)
        {
            var userMapped = _mapper.Map<User>(user);
            var result =  await _userService.CreateAsync(user: userMapped);
            var resultMapped = _mapper.Map<UserResponseDTO>(result);
            return resultMapped;
        }
    }
}