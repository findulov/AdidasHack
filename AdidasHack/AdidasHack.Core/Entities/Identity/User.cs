using AdidasHack.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities.Identity
{
    public class User : IdentityUser<int>, IBaseEntityIdentity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        
        public Gender Gender { get; set; }

        public int TeamId { get; set; }

        public int? GearId { get; set; }
        
        public Team Team { get; set; }

        public Gear Gear { get; set; }

        public ICollection<UserSport> UserSports { get; set; } = new HashSet<UserSport>();

        public ICollection<ChallengeResult> ChallengeResults { get; set; } = new HashSet<ChallengeResult>();
    }
}
