using AdidasHack.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdidasHack.Core.Entities
{
    public class UserSport : BaseEntityWithoutExplicitId
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [ForeignKey(nameof(Sport))]
        public int SportId { get; set; }

        public User User { get; set; }

        public Sport Sport { get; set; }
    }
}
