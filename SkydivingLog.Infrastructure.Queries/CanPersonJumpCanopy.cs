using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SkydivingLog.Infrastructure.Queries
{
    public class CanPersonJumpCanopy
    {
        public class Query : IRequest<bool>
        {
            public int PersonId { get; set; }
            
            public int CanopyId { get; set; }

            public int LeadWeightGrams { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, bool>
        {
            private readonly IDbConnection _connection;

            public QueryHandler(IDbConnection connection)
            {
                _connection = connection;
            }

            public Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                //Get jumper weight
                //Downsizing no worries...
                return Task.FromResult(true);
            }
        }
    }
}
