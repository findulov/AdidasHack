using AdidasHack.Core.Entities;
using AdidasHack.Core.Models;
using AdidasHack.Core.Models.Challenge;
using AdidasHack.Infrastructure.Repositories;
using AdidasHack.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository challengeRepository;
        private readonly IChallengeResultRepository challengeResultRepository;

        public ChallengeService(IChallengeRepository challengeRepository, IChallengeResultRepository challengeResultRepository)
        {
            this.challengeRepository = challengeRepository;
            this.challengeResultRepository = challengeResultRepository;
        }
        
        public IEnumerable<ChallengeModel> GetAllNearbyUser(int userId, double userLatitude, double userLongtitude, int distance)
        {
            List<ChallengeModel> challengeModels = new List<ChallengeModel>();

            var challenges = challengeRepository.GetAllWithCoordinates();

            foreach (var challenge in challenges)
            {
                bool isFound = false;

                foreach (var coordinate in challenge.Coordinates)
                {
                    if ((coordinate.Latitude - userLatitude) * (coordinate.Latitude - userLatitude) +
                        (coordinate.Longtitude - userLongtitude) * (coordinate.Longtitude - userLongtitude) <= distance * distance)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    challengeModels.Add(new ChallengeModel
                    {
                        Id = challenge.Id,
                        Name = challenge.Name,
                        Distance = challenge.Distance,
                        Pace = challenge.Pace,
                        Duration = challenge.DurationInSeconds,
                        Location = challenge.Location,
                        Difficulty = challenge.Difficulty,
                        Coordinates = challenge.Coordinates.Select(x => new ChallengeCoordinateModel
                        {
                            Latitude = x.Latitude,
                            Longtitude = x.Longtitude
                        }).ToList()
                    });

                    break;
                }
            }

            return challengeModels;
        }

        public IEnumerable<ChallengeResultModel> GetTopTenResults(int challengeId)
        {
            Random randomGenerator = new Random();

            var challengeResults = challengeResultRepository.GetTopResultsForChallenge(10, challengeId)
                .Select(x => new ChallengeResultModel
                {
                    Team = x.User.Team.Name,
                    TeamLogoImageName = x.User.Team.LogoImageName,
                    Points = randomGenerator.Next(50, 1200)
                }).OrderByDescending(x => x.Points)
                .ToList();

            return challengeResults;
        }
    }
}
