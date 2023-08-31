//using AspNet.Security.OAuth.Discord;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;

//namespace Endpoint.Controllers
//{
//    //public static class DiscordAuthenticationDefaults
//    //{

//    //}

//    [Authorize(AuthenticationSchemes = DiscordAuthenticationDefaults.AuthenticationScheme)]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {
//        [HttpGet("GetToken")]
//        public IActionResult GetToken()
//        {
//            var userId = User.Claims.First(c=> c.Type == ClaimTypes.NameIdentifier).Value;

//            var key = _configuration.GetValue<string>("Jwt:SigningKey");
//            var issuer = _configuration.GetValue<string>("Jwt:Issuer");
//            var audience = _configuration.GetValue<string>("Jwt:Audience");

//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var claims = new[] 
//            {
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                new Claim("id", userId)
//            };

//            var expires = DateTime.Now.AddDays(7);
//            var token = new JwtSecurityToken(issuer, audience, claims, expires: expires, signingCredentials: credentials);

//            var handler = new JwtSecurityTokenHandler().WriteToken(token);

//            return Ok(new
//            {
//                ApiToken = handler
//            });
//        }

//        public LoginController(IConfiguration configuration) => _configuration = configuration;

//        private readonly IConfiguration _configuration;
//    }
//}
