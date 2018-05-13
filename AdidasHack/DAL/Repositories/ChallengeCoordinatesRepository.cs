using AdidasHack.Core.Entities;
using AdidasHack.Infrastructure.Repositories;
using DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ChallengeCoordinatesRepository : BaseRepository<ChallengeCoordinate>, IChallengeCoordinatesRepository
    {
        public ChallengeCoordinatesRepository(AdidasDbContext db)
            : base(db)
        {
        }

        public IEnumerable<ChallengeCoordinate> GetByChallengeId(int challengeId)
        {
            return db.ChallengeCoordinates
                .Where(x => x.ChallengeId == challengeId)
                .ToList();
        }
    }
}
