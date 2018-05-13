using System.Collections.Generic;
using System.Linq;
using AdidasHack.Core.Entities;
using AdidasHack.Infrastructure.Repositories;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChallengeRepository : BaseRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(AdidasDbContext db)
            : base(db)
        {
        }

        public IEnumerable<Challenge> GetAllWithCoordinates()
        {
            return db.Challenges
                .Include(x => x.Coordinates)
                .ToList();
        }
    }
}
