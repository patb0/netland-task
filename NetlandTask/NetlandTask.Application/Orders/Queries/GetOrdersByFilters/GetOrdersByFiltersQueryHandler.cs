using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using NetlandTask.Application.Common;
using NetlandTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Orders.Queries.GetOrdersByFilters
{
    public class GetOrdersByFiltersQueryHandler : IRequestHandler<GetOrdersByFiltersQuery, IEnumerable<Order>>
    {
        private readonly CsvFile _csvFile;
        public GetOrdersByFiltersQueryHandler(CsvFile csvFile)
        {
            _csvFile = csvFile;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersByFiltersQuery request, CancellationToken cancellationToken)
        {
            using (var streamReader = new StreamReader(_csvFile.CsvPath))
            {
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.UTF8,
                    HasHeaderRecord = true,
                };

                using (var csvReader = new CsvReader(streamReader, csvConfiguration))
                {
                    var records = csvReader.GetRecords<Order>().ToList();

                    return await Task.FromResult(records);
                }
            }
        }
    }
}
