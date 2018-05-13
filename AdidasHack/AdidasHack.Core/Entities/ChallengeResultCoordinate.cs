using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Core.Entities
{
    public class ChallengeResultCoordinate : BaseEntityIdentity
    {
        public int ChallengeResultId { get; set; }

        public ChallengeResult ChallengeResult { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }
    }
}
