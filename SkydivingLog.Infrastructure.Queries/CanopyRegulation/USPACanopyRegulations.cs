using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;

namespace SkydivingLog.Infrastructure.Queries.CanopyRegulation
{
    public class UspaCanopyRegulations : CanopyRegulations
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
