using System.Collections.Generic;

namespace AdidasHack.Core.Entities
{
    public class ChallengeCoordinate : BaseEntityIdentity
    {
        public int ChallengeId { get; set; }

        public Challenge Challenge { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }
    }
}
