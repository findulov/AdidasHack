using AdidasHack.Core.Authentication;
using AdidasHack.Core.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdidasHack.Web.Api.Controllers
{
    [Route("api/auth")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : BaseApiController
    {
        private readonly SignInManager<User> signInManager;

        public AuthController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("asd");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthRequest authRequest)
        {
            var user = await signInManager.UserManager.FindByEmailAsync(authRequest.UserName);

            if (user != null)
            {
                var signInResult = await signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);

                if (signInResult.Succeeded)
                {
                    var claims = new []
                    {
                        new Claim(ClaimTypes.Name, authRequest.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Aghj2345tfa78hfbxgw453ry"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "AdidasHack",
                        audience: "AdidasHack",
                        claims: claims,
                        expires: DateTime.Now.AddHours(24),
                        signingCredentials: creds);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        type = "Bearer",
                        userId = user.Id
                    });
                }
            }

            return Unauthorized();
        }
    }
}
