using AdidasHack.Core.Models;
using AdidasHack.Core.Models.Challenge;
using System.Collections.Generic;

namespace AdidasHack.Infrastructure.Services
{
    public interface IChallengeService
    {
        IEnumerable<ChallengeModel> GetAllNearbyUser(int userId, double userLatitude, double userLongtitude, int distance);

        IEnumerable<ChallengeResultModel> GetTopTenResults(int challengeId);
    }
}
