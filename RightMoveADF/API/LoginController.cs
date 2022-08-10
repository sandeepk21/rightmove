using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RightMoveADF.Models;
using RightMoveADF.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RightMoveADF.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       
        // GET: api/<LoginController>
        [AllowAnonymous]
        [HttpPost("Admin")]
        public IActionResult Login([FromForm] UserViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });

                HttpContext.Session.SetString("Token", tokenString);
               

            }

            return response;
        }

        private string GenerateJSONWebToken(UserViewModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("BetaCoreAPI", "BetaCoreAPI",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserViewModel AuthenticateUser(UserViewModel login)
        {
            UserViewModel user = new UserViewModel();
            try
            {
                string cypherText = EncryptionModel.Encrypt(login.Password.ToString());
                using (var dbcontext = new CoreDbContext())
                {
                    var dbLogin = dbcontext.UserLogins.Where(x => x.UserId == login.EmailAddress && x.Upassword== cypherText).FirstOrDefault();
                    if (dbLogin != null)
                    {
                       user = new UserViewModel { EmailAddress = login.EmailAddress };
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return user;
        }
        
    }
}
