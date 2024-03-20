using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebAPIDatingAPP.DATA;
using WebAPIDatingAPP.DATA.migration;
using WebAPIDatingAPP.DTOs;
using WebAPIDatingAPP.Entities;

namespace WebAPIDatingAPP.Controllers
{
    public class AccountController : BaseApiController
    {
        public readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUsers>> Register(RegisterDto registerDto)
        {

            if (await UserExists(registerDto.Username)) return BadRequest("User Name already exist");

            using var hmac = new HMACSHA512();
            var users = new AppUsers()
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.AppUsers.Add(users);
            await _context.SaveChangesAsync();
            return users;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AppUsers>> Login (LoginDTo loginDTo)
        {
            var user = await _context.AppUsers.SingleOrDefaultAsync(x => x.UserName == loginDTo.Username);
            if (user == null)
            {
                return Unauthorized("Invalid Users");
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTo.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])return Unauthorized("Invalid Password");
            }

            return user;

        }
        private async Task <bool> UserExists( string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
