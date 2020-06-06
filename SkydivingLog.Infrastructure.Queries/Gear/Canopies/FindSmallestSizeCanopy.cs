using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SkydivingLog.Infrastructure.Queries.Associations;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.Gear.Canopies
{
    public class FindSmallestSizeCanopy
    {
        public class Query : IRequest<double>
        {
            public Association JumpingAssociation { get; set; }
            public double NakedWeightKg { get; set; }
            public double LeadWeightKg { get; set; }
            public int JumpNumbers { get; set; }
            public bool Elliptical { get; set; }
            public double TotalWeight => NakedWeightKg + LeadWeightKg + 10.0;
        }

        public class QueryHandler : IRequestHandler<Query, double>
        {

            private readonly IAssociationService _associationService;
            public QueryHandler(IAssociationService associationService)
            {
                _associationService = associationService;
            }

            public Task<double> Handle(Query request, CancellationToken cancellationToken)
            {
                var regulations = _associationService.GetCanopyRegulations(request.JumpingAssociation);
                var result = regulations.SmallestParachute(request.JumpNumbers, request.TotalWeight, request.Elliptical);

                return Task.FromResult(result);
            }
        }
    }
}
