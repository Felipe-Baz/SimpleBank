using simplebank.Exceptions;
using simplebank.Model;
using simplebank.Repositories.Interfaces;
using simplebank.Services.Interfaces;

namespace simplebank.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(User user)
        {
            if (user == null)
                throw new ValidationException("User is null.");

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
            var response = await _userRepository.GetByIdAsync(user.Id);
            return response;
        }
    }
}