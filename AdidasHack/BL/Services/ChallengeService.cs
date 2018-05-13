using AdidasHack.Core.Entities;
using AdidasHack.Infrastructure.Repositories;
using AdidasHack.Infrastructure.Services;
using System.Collections.Generic;

namespace BL.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository challengeRepository;

        public ChallengeService(IChallengeRepository challengeRepository)
        {
            this.challengeRepository = challengeRepository;
        }
        
        public IEnumerable<Challenge> GetNearby(double userLatitude, double userLongtitude, int distance)
        {
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
                    yield return challenge;
                    break;
                }
            }
        }
    }
}
