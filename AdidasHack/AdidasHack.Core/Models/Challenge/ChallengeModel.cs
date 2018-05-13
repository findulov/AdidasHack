using AdidasHack.Core.Entities;
using AdidasHack.Core.Models.Challenge;
using System.Collections.Generic;

namespace AdidasHack.Core.Models
{
    public class ChallengeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public int Pace { get; set; }

        public double Distance { get; set; }

        public string Sport { get; set; }

        public int Difficulty { get; set; }

        public string Location { get; set; }

        public List<ChallengeCoordinateModel> Coordinates { get; set; }
    }
}
