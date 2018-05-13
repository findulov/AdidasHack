using AdidasHack.Core.Models;
using AdidasHack.Infrastructure.Repositories;
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
        private readonly IChallengeRepository challengeRepository;

        public ChallengeController(IChallengeRepository challengeRepository, IChallengeService challengeService)
        {
            this.challengeRepository = challengeRepository;
            this.challengeService = challengeService;
        }

        [HttpGet]
        [Route("getAllNearbyUser")]
        public IActionResult GetAllNearbyUser(int userId, double userLatitude, double userLongtitude, int distance)
        {
            var challenges = challengeService.GetAllNearbyUser(userId, userLatitude, userLongtitude, distance);

            return Ok(challenges);
        }

        [HttpGet]
        [Route("getAllByUser")]
        public IActionResult GetAllByUser(int userId)
        {
            var challenges = challengeRepository.GetAllByUser(userId)
                .Select(x => new ChallengeModel
                {
                    Id = x.Id
                }).ToList();

            return Ok(challenges);
        }
    }
}
