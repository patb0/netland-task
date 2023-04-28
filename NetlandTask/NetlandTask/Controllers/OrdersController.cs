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
        public async Task<ActionResult> GetOrders(
            [FromQuery]FilterViewModel filters)
        {
            Console.ReadLine();

            return Ok();
        }
    }
}
