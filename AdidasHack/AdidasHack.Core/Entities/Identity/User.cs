using AdidasHack.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        
        public Gender Gender { get; set; }

        public int TeamId { get; set; }

        public int SportId { get; set; }
        
        public Team Team { get; set; }

        public ICollection<UserSport> UserSports { get; set; }
    }
}
