using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Domain.Entities
{
    public class Order
    {
        public string Number { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string OrderDate { get; set; }
        public string? ShipmentDate { get; set; }
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
        public float Value { get; set; }
    }
}
