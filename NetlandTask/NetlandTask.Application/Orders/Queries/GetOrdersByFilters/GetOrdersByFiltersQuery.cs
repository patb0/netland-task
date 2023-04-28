using MediatR;
using NetlandTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Orders.Queries.GetOrdersByFilters
{
    public class GetOrdersByFiltersQuery : IRequest<Order>
    {
        public FilterViewModel Filters { get; set; }
    }
}
