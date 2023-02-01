using AutoMapper;
using Conduit.Web.Interfaces;
using Conduit.Web.JWT;
using Conduit.Web.Models;
using Conduit.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace Conduit.Web.Controllers
{

    [ApiController]
    [Route("Authenticate")]
    public class AuthenticationController : Controller
    {
        private readonly JWTSetting setting;
        private readonly IAuthenticationService _authenticationService;
        private readonly IRefreshTokenGeneratorService _refreshTokenGeneratorService;
        private const string USERID = "UserId";
        public AuthenticationController(IOptions<JWTSetting> options, IAuthenticationService authenticationService, IRefreshTokenGeneratorService refreshTokenGeneratorService)
        {
           setting = options.Value;
           _authenticationService = authenticationService;
           _refreshTokenGeneratorService = refreshTokenGeneratorService;
        }

        [HttpPost("LogIn")]
        public IActionResult Login([FromBody] usercred usercred)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var userExist = _authenticationService.DoesTheUserExist(usercred.UserId);
            if (!userExist)
            {
                return Unauthorized();
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(setting.securityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(USERID, usercred.UserId.ToString()),
                }
                ),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenHandler.WriteToken(token);
            tokenResponse.JWTToken = finaltoken;
            tokenResponse.RefreshToken = _refreshTokenGeneratorService.GenerateToken(usercred.UserId);
            return Ok(tokenResponse);
        }

        [NonAction]
        public TokenResponse Authenticate(int userId, Claim[] claims)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(setting.securityKey);
            var tokenhandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                );
            tokenResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenhandler);
            tokenResponse.RefreshToken = _refreshTokenGeneratorService.GenerateToken(userId);
            return tokenResponse;
        }
     
        [Route("Refresh")]
        [HttpPost]
        public IActionResult Refresh([FromBody] TokenResponse tokenResponse)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenhandler.ValidateToken(tokenResponse.JWTToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.securityKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out securityToken);

            var _token = securityToken as JwtSecurityToken;

            if (_token != null && !_token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return Unauthorized();
            }

            var userIdClaim = principal.Claims.Where(c => c.Type == USERID).FirstOrDefault();
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var userId = Convert.ToInt32(userIdClaim.Value);
            

            //var userId = principal.Identity.Name;

             var _user = _refreshTokenGeneratorService.TokenExists(userId, tokenResponse.RefreshToken);
             if (_user == null)
             {
                 return Unauthorized();
             }
             TokenResponse _result = Authenticate(userId, principal.Claims.ToArray());
             return Ok(_result);
            
        }

        [HttpPost("LogOut")]
        public IActionResult Logout()
        {
            var userIdClaim = User.Claims.Where(c => c.Type == USERID).FirstOrDefault();
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var userId = Convert.ToInt32(userIdClaim.Value);

            var userExist = _authenticationService.DoesTheUserExist(userId);
            if (!userExist)
            {
                return Unauthorized();
            }
            var refreshToken = _refreshTokenGeneratorService.DeleteToken(userId);
            if (refreshToken == null)
            {
                return Unauthorized();
            }
            return Ok();
        }


    }
}
