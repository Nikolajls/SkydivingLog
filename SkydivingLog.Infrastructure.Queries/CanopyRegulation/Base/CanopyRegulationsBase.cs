using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base
{
    public abstract class CanopyRegulations<TAssociation> : ICanopyRegulations where TAssociation : IAssociation
    {
        public abstract bool CanJump(int jumpCount, double exitWeight, double squareFeet, bool isElliptical);
        public abstract double SmallestParachute(int jumpCount, double exitWeight, bool isElliptical);

        protected double CalculateSquareFeetLoad(double exitWeight, double canopySqft)
        {
            return (exitWeight * 1000) / canopySqft;
        }
    }
}
