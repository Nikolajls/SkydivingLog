using System;
using System.Collections.Generic;
using System.Text;

namespace SkydivingLog.Infrastructure.Queries.CanopyRegulations
{
    public abstract class CanopyRegulationsBase
    {
        public abstract bool CanJump(int jumpCount, double exitWeight, double squareFeet, bool isElliptical);
        public abstract double SmallestParachute(int jumpCount, double exitWeight, double squareFeet, bool isElliptical, double minimum = 37.0);

        protected double CalculateSquareFeetLoad(double exitWeight, double canopySqft)
        {
            return (exitWeight * 1000) / canopySqft;
        }
    }
}
