using Microsoft.AspNetCore.Mvc;

namespace DealershipRun.AppHost.User
{
    [ApiController]
    [Route("DealershipRun/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]  RegisterDto dto)
        {
            var user = new UserEntity
            {
                UserName = dto.Username,
                Email = dto.Email
            };
            var created = await _userService.Register(user, dto.Password);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new UserDto(
                created.Id, created.UserName, created.Email, created.Role)); 
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _userService.Login(dto.Email, dto.Password);
            return Ok(new { token });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var user = await _userService.GetById(id);
            return Ok(new UserDto(
                user.Id, user.UserName, user.Email, user.Role
            ));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _userService.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}/role")]
        public async Task<IActionResult> UpdateRole(long id, [FromBody] Role role)
        {
            await _userService.UpdateRole(id, role);
            return NoContent();
        }
    }
}
