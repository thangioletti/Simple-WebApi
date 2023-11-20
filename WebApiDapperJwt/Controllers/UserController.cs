using HoltiHubDapper.Contracts.Repository;
using HoltiHubDapper.Converters;
using HoltiHubDapper.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HoltiHubDapper.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(UserDTO user)
        {
            await _user.Add(UserConverter.Convert(user));
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            try
            {
                string token = await _user.LogIn(email, password);
                return Ok(new { Token = token });
            }
            catch (Exception e)
            {
              return BadRequest(new { Error = e.Message });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _user.Get());
        }


    }

}

