using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SkydivingLog.Infrastructure.Queries
{
    public class CanPersonJumpCanopy
    {
        public class Query : IRequest<bool>
        {
            /// <summary>
            /// The naked weight of the jumper in kilograms
            /// </summary>
            public double NakedWeightKg { get; set; }
            /// <summary>
            /// Weight of lead the jumper wears if any
            /// </summary>
            public double LeadWeightKg { get; set; }

            /// <summary>
            /// Number of jumps the jumper has
            /// </summary>
            public int JumpNumbers { get; set; }

            /// <summary>
            /// If the canopy is considered elliptical
            /// </summary>
            public bool Elliptical { get; set; }

            /// <summary>
            /// The size of the canopy to test if the jumper may jump
            /// </summary>
            public double CanopySqft { get; set; }

            /// <summary>
            /// Property that calculates the total/exit weight of the jumper
            /// </summary>
            public double TotalWeight => NakedWeightKg + LeadWeightKg + 10.0;
        }

        public class QueryHandler : IRequestHandler<Query, bool>
        {
            public Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                //A person with 400 jumps may jump any "normal type canoyp"
                if (request.JumpNumbers >= 400)
                    return Task.FromResult(true);

                //A jumper with below 400 jumps may not jump smaller than 120 sqft
                if (request.CanopySqft < 120)
                    return Task.FromResult(false);

                var sqftLoad = CalculateSquareFeetLoad(request.TotalWeight, request.CanopySqft);

                //A jumper with less than 200 jumps or if the canopy is elliptical may not jump a canopy that's loaded with more than 500 grams per sqft
                if (request.JumpNumbers < 200 || request.Elliptical)
                    return Task.FromResult(sqftLoad <= 500);

                //Implicitely here the jumper has more than 200 and is not trying an elliptical thus may load with a maximum of 650 grams per sqft
                return Task.FromResult(sqftLoad <= 650);
            }

            private double CalculateSquareFeetLoad(double totalWeight, double CanopySqft)
            {
                return (totalWeight * 1000) / CanopySqft;
            }
        }
    }
}
