using AdidasHack.Core.Models;
using AdidasHack.Core.Models.Challenge;
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
        private readonly IChallengeCoordinatesRepository challengeCoordinatesRepository;

        public ChallengeController(
            IChallengeRepository challengeRepository,
            IChallengeService challengeService,
            IChallengeCoordinatesRepository challengeCoordinatesRepository)
        {
            this.challengeRepository = challengeRepository;
            this.challengeService = challengeService;
            this.challengeCoordinatesRepository = challengeCoordinatesRepository;
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
                    Id = x.Id,
                    Name = x.Name,
                    Distance = x.Distance,
                    Pace = x.Pace,
                    Duration = x.DurationInSeconds,
                    Sport = x.Sport.Name,
                    Location = x.Location,
                    Difficulty = x.Difficulty,
                    Coordinates = x.Coordinates.Select(y => new ChallengeCoordinateModel
                    {
                        Latitude = y.Latitude,
                        Longtitude = y.Longtitude
                    }).ToList()
                }).ToList();

            return Ok(challenges);
        }

        [HttpGet]
        [Route("getCoordinates")]
        public IActionResult GetCoordinates(int challengeId)
        {
            var coordinates = challengeCoordinatesRepository.GetByChallengeId(challengeId);
            
            return Ok(coordinates.Select(x => $"{x.Latitude}:{x.Longtitude}"));
        }
    }
}
