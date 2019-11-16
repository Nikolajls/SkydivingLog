using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SkydivingLog.Infrastructure.Queries
{
    public class FindSmallestSizeCanopy
    {
        public class Query : IRequest<double>
        {
            public double NakedWeightKg { get; set; }
            public double LeadWeightKg { get; set; }
            public int JumpNumbers { get; set; }
            public bool Elliptical { get; set; }
            public double TotalWeight => NakedWeightKg + LeadWeightKg + 10.0;
        }

        public class QueryHandler : IRequestHandler<Query, double>
        {
         

            public Task<double> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = 37.0;
                if (request.JumpNumbers >= 400) return Task.FromResult(result);
                var maxLoadPerSquare = request.JumpNumbers < 200 || request.Elliptical ? 0.5 : 0.650;
                result = request.TotalWeight / maxLoadPerSquare;
                return Task.FromResult(result);
            }
        }
    }
}
