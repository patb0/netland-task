using CsvHelper.Configuration;
using NetlandTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Mapping
{
    public class OrderClassMap : ClassMap<Order>
    {
        public OrderClassMap()
        {
            Map(m => m.Number).Name("Number");
            Map(m => m.ClientCode).Name("ClientCode");
            Map(m => m.ClientName).Name("ClientName");
            Map(m => m.OrderDate).Name("OrderDate");
            Map(m => m.ShipmentDate).Name("ShipmentDate");
            Map(m => m.Quantity).Name("Quantity");
            Map(m => m.Confirmed).Name("Confirmed");
            Map(m => m.Value).Name("Value");
        }
    }
}
