using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Orders.Queries.GetOrdersByFilters
{
    public class GetOrdersByFiltersQueryValidator : AbstractValidator<GetOrdersByFiltersQuery>
    {
        public GetOrdersByFiltersQueryValidator()
        {
            //rules for date as string (31.12.2023)
            RuleFor(a => a.Filters.StartDate)
                .Matches(@"^(0?[1-9]|[1-2][0-9]|3[0-1])\.(0?[1-9]|1[0-2])\.(200[0-9]|201[0-9]|202[0-3])$")
                .WithMessage("Invalid date format! (dd.MM.yyyy)")
                .When(x => x.Filters.StartDate != string.Empty);
                

            RuleFor(a => a.Filters.EndDate)
                .Matches(@"^(0?[1-9]|[1-2][0-9]|3[0-1])\.(0?[1-9]|1[0-2])\.(200[0-9]|201[0-9]|202[0-3])$")
                .WithMessage("Invalid date format! (dd.MM.yyyy)")
                .When(x => x.Filters.EndDate != string.Empty);
        }
    }
}
