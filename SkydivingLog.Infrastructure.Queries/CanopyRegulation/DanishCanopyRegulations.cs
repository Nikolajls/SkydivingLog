using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;

namespace SkydivingLog.Infrastructure.Queries.CanopyRegulation
{
    public class DanishCanopyRegulations : CanopyRegulations
    {
        public override bool CanJump(int jumpCount, double exitWeight, double squareFeet, bool isElliptical)
        {
            //A person with 400 jumps may jump any "normal type canopy"
            if (jumpCount >= 400)
                return true;

            //A jumper with below 400 jumps may not jump smaller than 120 sqft
            if (squareFeet < 120)
                return false;

            var sqftLoad = CalculateSquareFeetLoad(exitWeight, squareFeet);

            //A jumper with less than 200 jumps or if the canopy is elliptical may not jump a canopy that's loaded with more than 500 grams per sqft
            if (jumpCount < 200 || isElliptical)
                return sqftLoad <= 500;

            //Implicitely here the jumper has more than 200 and is not trying an elliptical thus may load with a maximum of 650 grams per sqft
            return sqftLoad <= 650;
        }

        public override double SmallestParachute(int jumpCount, double exitWeight, bool isElliptical)
        {
            if (jumpCount >= 400)
                return 37.0d;
            var maxLoadPerSquare = jumpCount < 200 || isElliptical ? 0.5 : 0.650;
            var result = exitWeight / maxLoadPerSquare;
            return result;
        }
    }
}
