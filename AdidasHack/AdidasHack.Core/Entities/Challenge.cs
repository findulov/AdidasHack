using AdidasHack.Core.Entities.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities
{
    public class Challenge : BaseEntity
    {
        public string Location { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<ChallengeResult> Results { get; set; }
    }
}
