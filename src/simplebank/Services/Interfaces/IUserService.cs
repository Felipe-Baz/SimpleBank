using simplebank.Model;

namespace simplebank.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);

        public Task<List<User>> ListAsync();

        public Task<User> DetailsAsync(int id);

        public Task<User> UpdateAsync(User user);

        public Task<User> DeleteAsync(int id);
    }
}