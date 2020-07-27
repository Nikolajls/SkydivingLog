﻿using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.CanopyRegulation
{
    public class UspaCanopyRegulations : CanopyRegulations<UspaAssocation>
    {
        //Land of the free rules!
        public override bool CanJump(int jumpCount, double exitWeight, double squareFeet, bool isElliptical)
        {
            return true;
        }

        public override double SmallestParachute(int jumpCount, double exitWeight, bool isElliptical)
        {
            return 1;
        }
    }
}
