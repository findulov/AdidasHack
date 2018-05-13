using AdidasHack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Infrastructure.Repositories
{
    public interface IChallengeRepository : IBaseRepository<Challenge>
    {
        IEnumerable<Challenge> GetAllWithCoordinates();
    }
}
