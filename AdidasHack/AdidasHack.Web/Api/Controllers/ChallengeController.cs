using AdidasHack.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdidasHack.Web.Api.Controllers
{
    [Route("api/challenge")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChallengeController : BaseApiController
    {
        private readonly IChallengeService challengeService;

        public ChallengeController(IChallengeService challengeService)
        {
            this.challengeService = challengeService;
        }

        [HttpGet]
        [Route("getNearbyMe")]
        public IActionResult GetNearbyMe(double userLatitude, double userLongtitude, int distance)
        {
            var challenges = challengeService.GetNearby(userLatitude, userLongtitude, distance).ToList();

            return Ok(challenges);
        }
    }
}
