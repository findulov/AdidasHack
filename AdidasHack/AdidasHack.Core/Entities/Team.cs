using AdidasHack.Core.Entities.Identity;
using System.Collections;
using System.Collections.Generic;

namespace AdidasHack.Core.Entities
{
    public class Team : BaseEntity
    {
        public string LogoImageName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
