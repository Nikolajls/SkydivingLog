﻿using System;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace SkydivingLog.Infrastructure.Queries.Gear.Canopies
{
    public class FindAllCanopies
    {
        public class Query : IRequest<List<Result>>
        {

        }

        public class Result
        {
            public int Id { get; set; }
            public int SquareFoot { get; set; }
            public string SerialNumber { get; set; }
            public DateTime ManufacturedDate { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<Result>>
        {
            private readonly IDbConnection _connection;


            public QueryHandler(IDbConnection connection)
            {
                _connection = connection;
            }

            public async Task<List<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _connection.QueryAsync<Result>("SELECT * FROM [Gear].[Canopies]");
                var canopies = data.ToList();
                return canopies;
            }
        }
    }
}