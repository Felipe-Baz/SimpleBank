using simplebank.Facades.interfaces;
using simplebank.Model;
using simplebank.Services.Interfaces;

namespace simplebank.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;

        public UserFacade(IUserService userService)
        {
            _userService = userService;
        }

        async Task<User> IUserFacade.CreateAsync(User user)
        {
            return await _userService.CreateAsync(user: user);
        }
    }
}