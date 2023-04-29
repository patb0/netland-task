using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetlandTask.Application.Orders.Queries.GetOrdersByFilters;
using NetlandTask.Domain.Entities;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NetlandTask.Controllers
{
    [Route("api/orders")]
    public class OrdersController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders([FromQuery]FilterViewModel filters)
        {
            var result = await Mediator.Send(new GetOrdersByFiltersQuery()
            {
                Filters = filters
            });

            return Ok(result);
        }
    }
}
