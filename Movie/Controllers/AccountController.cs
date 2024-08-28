using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movie.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Movie.Entity;
using Movie.Services.LoginServices;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet("/login")]
        public async Task<ActionResult> Login(string Email ,string Password )
        {
            if (ModelState.IsValid) {
                bool result = await CheckLogin.LoginChecker(userManager, Email,Password);
                if (!result) {
                    return Unauthorized();
                }
                var login = new LoginViewModel
                {
                Email = Email,
                Password = Password
                };
string token = GenerateToken(login);
                return Ok(token);
            }
            return Unauthorized();
        }
        private string GenerateToken(LoginViewModel login) {
            string key = "Loai saber Elsayed BulNoor Tyseer Hesham AbulNoor";
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(key));
            var signingCredentional = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, login.Email));
            var token = new JwtSecurityToken(
                claims: claims , 
                expires:DateTime.Now.AddDays(1) , 
                signingCredentials:signingCredentional);
            var finalToken = new JwtSecurityTokenHandler().WriteToken(token);
            return finalToken;
        }
        
    }
}
