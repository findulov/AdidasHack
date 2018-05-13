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

        public IEnumerable<Challenge> GetAllByUser(int userId)
        {
            return db.Challenges
                .Include(x => x.Results)
                .Include(x => x.Coordinates)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public IEnumerable<Challenge> GetAllWithCoordinates(int? userId = null)
        {
            var query = db.Challenges.AsQueryable();

            if (userId != null)
            {
                query = query.Where(x => x.UserId == userId.Value);
            }

            return query
                .Include(x => x.Coordinates)
                .ToList();
        }
    }
}
