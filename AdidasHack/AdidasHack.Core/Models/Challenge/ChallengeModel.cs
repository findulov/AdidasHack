using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Core.Models
{
    public class ChallengeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public int Pace { get; set; }

        public double Distance { get; set; }
    }
}
