using simplebank.Model;

namespace simplebank.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);
    }
}