using AdidasHack.Core.Enums;
using AdidasHack.Core.Models.Team;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Core.Models.User
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string Sport { get; set; }

        public TeamViewModel Team { get; set; }
    }
}
