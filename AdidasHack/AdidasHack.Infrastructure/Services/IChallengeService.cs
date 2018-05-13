using AdidasHack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasHack.Infrastructure.Services
{
    public interface IChallengeService
    {
        IEnumerable<Challenge> GetNearby(double userLatitude, double userLongtitude, int distance);
    }
}
