using simplebank.Model;

namespace simplebank.Facades.interfaces
{
    public interface IUserFacade
    {
        public Task<User> CreateAsync(User user);
    }
}