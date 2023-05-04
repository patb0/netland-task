using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base("Order/s not found!")
        {

        }
    }
}
