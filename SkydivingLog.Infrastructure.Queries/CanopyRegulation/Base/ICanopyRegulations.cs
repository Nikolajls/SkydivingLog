namespace SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base
{
    public interface ICanopyRegulations
    {
        bool CanJump(int jumpCount, double exitWeight, double squareFeet, bool isElliptical);
        double SmallestParachute(int jumpCount, double exitWeight,bool isElliptical);
    }
}