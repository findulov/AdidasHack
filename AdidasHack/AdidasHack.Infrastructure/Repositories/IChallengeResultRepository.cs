using AdidasHack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Infrastructure.Repositories
{
    public interface IChallengeResultRepository : IBaseRepository<ChallengeResult>
    {
        IEnumerable<ChallengeResult> GetTopResultsForChallenge(int topNumber, int challengeId);
    }
}
