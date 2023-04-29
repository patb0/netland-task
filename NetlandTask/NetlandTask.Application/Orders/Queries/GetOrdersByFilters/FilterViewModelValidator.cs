using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application.Orders.Queries.GetOrdersByFilters
{
    public class FilterViewModelValidator : AbstractValidator<FilterViewModel>
    {
        public FilterViewModelValidator()
        {
            //rules for date
            RuleFor(a => a.StartDate)
                .Matches(@"^(0?[1-9]|[1-2][0-9]|3[0-1])\.(0?[1-9]|1[0-2])\.(200[0-9]|201[0-9]|202[0-3])$")
                .WithMessage("Invalid date format! (dd.MM.yyyy)");

            RuleFor(a => a.EndDate)
                .Matches(@"^(0?[1-9]|[1-2][0-9]|3[0-1])\.(0?[1-9]|1[0-2])\.(200[0-9]|201[0-9]|202[0-3])$")
                .WithMessage("Invalid date format! (dd.MM.yyyy)");
        }
    }
}
