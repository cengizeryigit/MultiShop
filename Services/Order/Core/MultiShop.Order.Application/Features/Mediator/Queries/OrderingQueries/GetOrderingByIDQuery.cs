using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIDQuery:IRequest<GetOrderingByIDQueryResult>
    {
        public int Id { get; set; }
        public GetOrderingByIDQuery(int id)
        {
            Id = id;
        }
    }
}
