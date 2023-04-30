using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetlandTask.Application.Orders.Queries.GetOrdersByFilters
{
    public class FilterViewModel
    {
        public string? Number { get; set; } = string.Empty;
        public string? StartDate { get; set; } = null;
        public string? EndDate { get; set; } = null;
        public ICollection<string>? ClientsCode { get; set; } = null;
    }
}
