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

        public int DurationInSeconds { get; set; }

        public int Pace { get; set; }

        public double Distance { get; set; }

        public ICollection<ChallengeResult> Results { get; set; }

        public ICollection<ChallengeCoordinate> Coordinates { get; set; }
    }
}
