using System.Collections;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities
{
    public class Gear : BaseEntityIdentity
    {
        public string Top { get; set; }

        public string Bottom { get; set; }

        public string Shoes { get; set; }

        public ICollection<GearAccessory> GearAccessories { get; set; }
    }
}
