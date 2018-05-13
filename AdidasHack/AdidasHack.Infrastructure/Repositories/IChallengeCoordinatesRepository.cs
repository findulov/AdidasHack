using AdidasHack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Infrastructure.Repositories
{
    public interface IChallengeCoordinatesRepository : IBaseRepository<ChallengeCoordinate>
    {
        IEnumerable<ChallengeCoordinate> GetByChallengeId(int challengeId);
    }
}
