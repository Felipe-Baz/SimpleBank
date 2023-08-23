using Microsoft.AspNetCore.Mvc;
using simplebank.Exceptions;
using simplebank.Facades.interfaces;
using simplebank.Model;

namespace simplebank.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserFacade _userFacade;

        public UserController(
            ILogger<UserController> logger,
            IUserFacade userFacade
        ) {
            _logger = logger;
            _userFacade = userFacade;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreatePostAsync(
            [FromBody] User user
        ) {
            try
            {
                return Ok(
                    await _userFacade.CreateAsync(user: user)
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}