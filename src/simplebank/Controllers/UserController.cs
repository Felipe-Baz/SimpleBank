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
        private readonly IUserFacade _userFacade;

        public UserController(
            ILogger<UserController> logger,
            IUserFacade userFacade
        ) {
            _userFacade = userFacade;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> CreateAsync(
            [FromBody] UserCreateDTO user
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

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> ListAsync()
        {
            try
            {
                return Ok(
                    await _userFacade.ListAsync()
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> DetailsAsync(
            int id
        )
        {
            try
            {
                return Ok(
                    await _userFacade.DetailsAsync(id: id)
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserResponseDTO>> UpdateAsync(
            [FromBody] UserUpdateDTO user
        )
        {
            try
            {
                return Ok(
                    await _userFacade.UpdateAsync(user: user)
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResponseDTO>> DeleteAsync(
            int id
        )
        {
            try
            {
                return Ok(
                    await _userFacade.DeleteAsync(id: id)
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}