using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using FluentValidation.Results;
using MediatR;
using NetlandTask.Application.Common;
using NetlandTask.Application.Mapping;
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
        private readonly IMapper _mapper;
        public GetOrdersByFiltersQueryHandler(CsvFile csvFile, IMapper mapper)
        {
            _csvFile = csvFile;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersByFiltersQuery request, CancellationToken cancellationToken)
        {
            using (var streamReader = new StreamReader(_csvFile.CsvPath))
            {
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Encoding = Encoding.UTF8,
                    Delimiter = ",",
                    Quote = '"',
                    HasHeaderRecord = true
                };

                using (var csvReader = new CsvReader(streamReader, csvConfiguration))
                {
                    //to do:
                    //- map for get records<Order>
                    //- save date from csv as D-M-Y, not M-D-Y
                    //- add filters handling

                    csvReader.Context.RegisterClassMap<OrderClassMap>();

                    var records = csvReader.GetRecords<Order>()
                      .Select(x => new Order()
                      {
                          Number = x.Number.Replace("\"", "").Replace(",", ""),
                          ClientCode = x.ClientCode.Replace("\"", ""),
                          ClientName = x.ClientName.Replace("\"", ""),
                          OrderDate = x.OrderDate,
                          ShipmentDate = x.ShipmentDate,
                          Quantity = x.Quantity,
                          Confirmed = x.Confirmed,
                          Value = x.Value
                      }).ToList();

                    return await Task.FromResult(records);
                }
            }
        }
    }
}
