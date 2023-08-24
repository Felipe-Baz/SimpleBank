using simplebank.Exceptions;
using simplebank.Extensions;
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
            
            Validate(user);

            user.SetCreated();
            user.Status = "CREATED";
            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();
            var response = await _userRepository.GetByIdAsync(user.Id);
            return response;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                user.Status = "DELETED";
                await _userRepository.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> DetailsAsync(int id)
        {
            var response = await _userRepository.GetByIdAsync(id);
            return response;
        }

        public User GetUserByIdWithDeleted(int id)
        {
            var response = _userRepository.GetUserByIdWithDeleted(id);
            return response;
        }

        public async Task<List<User>> ListAsync()
        {
            var response = await _userRepository.GetAllAsync();
            return response.ToList();
        }

        public async Task<User> UpdateAsync(User user)
        {
            if (user == null)
                throw new ValidationException("User is null.");
            
            Validate(user);

            user.SetUpdate();
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            var response = await _userRepository.GetByIdAsync(user.Id);
            return response;
        }

        private static void Validate(User user)
        {
            user.ValidateEmail();

            user.ValidatePhoneNumber();
        }
    }
}