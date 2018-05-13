using AdidasHack.Core.Entities.Identity;
using System;

namespace AdidasHack.Core.Entities
{
    public class ChallengeResult : BaseEntityIdentity
    {
        public int ChallengeId { get; set; }

        public Challenge Challenge { get; set; }

        public DateTime TimeAchieved { get; set; }

        public int DurationInSeconds { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
