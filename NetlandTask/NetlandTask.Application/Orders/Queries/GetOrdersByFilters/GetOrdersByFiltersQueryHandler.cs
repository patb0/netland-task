using MediatR;
using NetlandTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Orders.Queries.GetOrdersByFilters
{
    public class GetOrdersByFiltersQueryHandler : IRequestHandler<GetOrdersByFiltersQuery, Order>
    {
        public async Task<Order> Handle(GetOrdersByFiltersQuery request, CancellationToken cancellationToken)
        {

            var x = new Order()
            {
                ClientCode = "xx",
                ClientName = "xx",
                OrderDate = DateTime.Now,
                Confirmed = false,
                Number = "xx",
                Quantity = 1,
                ShipmentDate = DateTime.Now,
                Value = 1
            };

            return x;
        }
    }
}
