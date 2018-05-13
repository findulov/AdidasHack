using AdidasHack.Core.Entities.Identity;
using AdidasHack.Infrastructure.Repositories;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AdidasDbContext db)
            : base(db)
        {
        }

        public override User GetById(int id)
        {
            return db.Users
                .Include(x => x.UserSports)
                    .ThenInclude(x => x.Sport)
                .Include(x => x.Team)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
