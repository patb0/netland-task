using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;
using NetlandTask.Application.Common;
using NetlandTask.Application.Exceptions;
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
                    Delimiter = ",",
                    Quote = '"',
                    HasHeaderRecord = true,
                };

                using (var csvReader = new CsvReader(streamReader, csvConfiguration))
                {
                    csvReader.Context.RegisterClassMap<OrderClassMap>();

                    //check orders based on filters
                    var filteredOrders = csvReader.GetRecords<Order>()
                        .Where(i => i.Number.Contains(request.Filters.Number)
                          && (string.IsNullOrEmpty(request.Filters.StartDate)
                            || i.OrderDate >= DateTime.ParseExact(
                                request.Filters.StartDate,
                                "dd.MM.yyyy",
                                CultureInfo.InvariantCulture))
                          && (string.IsNullOrEmpty(request.Filters.EndDate)
                            || i.OrderDate <= DateTime.ParseExact(
                                request.Filters.EndDate, 
                                "dd.MM.yyyy",
                                CultureInfo.InvariantCulture))
                          && (request.Filters.ClientsCode == null
                            || request.Filters.ClientsCode.Any(
                                y => i.ClientCode.Contains(y))))
                        .ToList();

                    if(filteredOrders.Count == 0)
                    {
                        throw new OrderNotFoundException();
                    }

                    //create clean output
                    var orders = filteredOrders.Select(x => 
                        new Order()
                          {
                              Number = x.Number.Replace("\"", ""),
                              ClientCode = x.ClientCode.Replace("\"", ""),
                              ClientName = x.ClientName.Replace("\"", ""),
                              OrderDate = x.OrderDate,
                              ShipmentDate = x.ShipmentDate,
                              Quantity = x.Quantity,
                              Confirmed = x.Confirmed,
                              Value = x.Value
                          })
                        .ToList();

                    return await Task.FromResult(orders);
                }
            }
        }
    }
}
