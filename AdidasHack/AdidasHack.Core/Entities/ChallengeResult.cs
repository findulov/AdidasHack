using System.Collections;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities
{
    public class ChallengeResult : BaseEntityIdentity
    {
        public int ChallengeId { get; set; }

        public Challenge Challenge { get; set; }

        public ICollection<ChallengeResultCoordinate> Coordinates { get; set; }
    }
}
