using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace SkydivingLog.Infrastructure.Queries.Persons
{
    public class GetPersonNameById
    {
        public class Query : IRequest<Result>
        {
            public int Id { get; set; }
        }

        public class Result
        {
            public string Name { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            private readonly IDbConnection _connection;

            public QueryHandler(IDbConnection connection)
            {
                _connection = connection;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _connection.QueryFirstOrDefaultAsync<Result>("SELECT * FROM [Person].[Persons] WHERE Id = @Id", request);

                return data;
            }
        }
    }
}
