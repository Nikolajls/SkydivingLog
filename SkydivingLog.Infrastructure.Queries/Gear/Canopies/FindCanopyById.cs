using System;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using SkydivingLog.Models.Gears;

namespace SkydivingLog.Infrastructure.Queries.Gear.Canopies
{
    public class FindCanopyById
    {
        public class Query : IRequest<Result>
        {
            public int Id { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }
            public int SquareFoot { get; set; }
            public string SerialNumber { get; set; }
            public DateTime ManufacturedDate { get; set; }
            public string ModelName { get; set; }
            public int Cells { get; set; }
            public bool Elliptical { get; set; }
            public CanopyType Type { get; set; }
            public CanopyLevel Level { get; set; }
            public string ManufacturerName { get; set; }

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

                var canopy = await _connection.QueryFirstOrDefaultAsync<Result>("[Gear].[FindCanopyById]",
                    new {request.Id},
                    commandType:CommandType.StoredProcedure);


                return canopy; 
            }
        }
    }
}
