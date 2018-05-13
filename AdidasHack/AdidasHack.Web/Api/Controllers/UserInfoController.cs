using AdidasHack.Core.Entities.Identity;
using AdidasHack.Core.Models.Team;
using AdidasHack.Core.Models.User;
using AdidasHack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdidasHack.Web.Api.Controllers
{
    [Route("api/userInfo")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserInfoController : BaseApiController
    {
        private readonly IUserRepository userRepository;

        public UserInfoController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("getUserInfo")]
        public IActionResult GetUserInfo(int userId)
        {
            var user = userRepository.GetById(userId);

            if (user == null)
            {
                return BadRequest();
            }

            var userInfo = new UserProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Gender = user.Gender,
                Sport = string.Join(", ", user.UserSports.Select(x => x.Sport.Name)),
                Team = new TeamViewModel
                {
                    Name = user.Team.Name
                }
            };

            if (!string.IsNullOrEmpty(user.Team.LogoImageName))
            {
                var logoImage = Image.FromFile($"wwwroot/images/{user.Team.LogoImageName}");

                using (MemoryStream ms = new MemoryStream())
                {
                    logoImage.Save(ms, ImageFormat.Png);

                    userInfo.Team.LogoImageBytes = ms.ToArray();
                }

            }

            return Ok(userInfo);
        }
    }
}
