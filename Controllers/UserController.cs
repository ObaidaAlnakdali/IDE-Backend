using IDE_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDE_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDEContext _context;
        public UserController(IDEContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Create(CreateUserDto request)
        {
            try
            {
                var newUser = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                };
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok(newUser);
            } catch
            {
                return BadRequest("add user is not true");
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginUserDto request)
        {
            var Olduser = await _context.Users.Where(x => x.Email == request.Email && x.Password == request.Password).ToListAsync();

            if (Olduser.Count == 0)
                return BadRequest("Email or Password is not true");
            else
                return Ok(Olduser);
        }
    }
}
