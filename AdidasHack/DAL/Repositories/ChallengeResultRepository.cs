using AdidasHack.Core.Entities;
using AdidasHack.Infrastructure.Repositories;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ChallengeResultRepository : BaseRepository<ChallengeResult>, IChallengeResultRepository
    {
        public ChallengeResultRepository(AdidasDbContext db) : base(db)
        {
        }

        public IEnumerable<ChallengeResult> GetTopResultsForChallenge(int topNumber, int challengeId)
        {
            return db.ChallengeResults
                .Include(x => x.User)
                        .ThenInclude(x => x.Team)
                .Include(x => x.Challenge)
                .OrderBy(x => x.DurationInSeconds)
                .Take(topNumber)
                .ToList();
        }
    }
}
