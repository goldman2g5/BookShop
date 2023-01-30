using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BookShop.Client.Data;
using BookShop.Client.Models;
using BookShop.Server.Models;
using BookShop.Server.Data;
using BookShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BookShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            User user = new User
            {
                Username = request.Username,
                Password = request.Password
            };
            await UserService.Add(user);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            List<User> users = await UserService.GetAll();
            if (!users.Exists(u => u.Username == request.Username))
            {
                return BadRequest("User not found");
            }
            User user = users.Find(u => u.Username == request.Username);
            if (user.Password != request.Password)
            {
                return BadRequest("Wrong password");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                 claims: claims,
                 expires: DateTime.Now.AddDays(7),
                 signingCredentials: creds
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
