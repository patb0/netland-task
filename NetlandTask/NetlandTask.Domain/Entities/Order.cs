using System;
using System.Collections.Generic;
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
        public DateTime OrderDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int Quantity { get; set; }
        public bool Confirmed { get; set; }
        public float Value { get; set; }
    }
}
