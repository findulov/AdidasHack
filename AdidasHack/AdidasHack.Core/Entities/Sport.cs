using AdidasHack.Core.Entities.Identity;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities
{
    public class Sport : BaseEntity
    {
        public ICollection<User> Users { get; set; }

        public ICollection<UserSport> UserSports { get; set; }
    }
}
