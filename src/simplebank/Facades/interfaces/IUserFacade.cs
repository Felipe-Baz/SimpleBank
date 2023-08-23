using simplebank.Model;

namespace simplebank.Facades.interfaces
{
    public interface IUserFacade
    {
        public Task<UserResponseDTO> CreateAsync(UserCreateDTO user);

        public Task<List<UserResponseDTO>> ListAsync();

        public Task<UserResponseDTO> DetailsAsync(int id);

        public Task<UserResponseDTO> UpdateAsync(UserUpdateDTO user);

        public Task<UserResponseDTO> DeleteAsync(int id);
    }
}