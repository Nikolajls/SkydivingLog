using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SkydivingLog.Infrastructure.Queries.Associations;
using SkydivingLog.Infrastructure.Queries.CanopyRegulation.Base;
using SkydivingLog.Models.Associations;

namespace SkydivingLog.Infrastructure.Queries.Gear.Canopies
{
    public class CanPersonJumpCanopy
    {
        public class Query : IRequest<bool>
        {
            public Association JumpingAssociation { get; set; }
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
            private readonly IAssociationService _associationService;
            public QueryHandler(IAssociationService associationService)
            {
                _associationService = associationService;
            }

            public Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var regulations = _associationService.GetCanopyRegulations(request.JumpingAssociation);
                var result = regulations.CanJump(request.JumpNumbers, request.TotalWeight, request.CanopySqft, request.Elliptical);

                return Task.FromResult(result);
            }

        }
    }
}
