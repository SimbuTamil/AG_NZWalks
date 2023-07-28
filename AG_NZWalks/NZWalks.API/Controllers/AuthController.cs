using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenhandler _tokenhandler;
        public AuthController(IUserRepository userRepository , ITokenhandler tokenhandler)
        {
            _userRepository = userRepository;
            _tokenhandler = tokenhandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> ValidateUser(Models.DTO.UserDTO userDTO)
        {
          var user  = await _userRepository.ValidateUsers(userDTO.UserName ,userDTO.password);

            if(user !=null)
            {
             var token = await _tokenhandler.CreateTokenAsyn(user);
                return Ok(token);
            }

            return BadRequest("User not valid");
        }
    }
}
