using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetlandTask.Application.Common;
using NetlandTask.Application.Common.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetlandTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services, IConfiguration configuration)
        {
            //Add mediatr
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Add automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Add fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            //Add csv path from appsettings.json
            var csvFile = new CsvFile();

            configuration.Bind("CsvFile", csvFile);
            services.AddSingleton(csvFile);


            return services;
        }
    }
}
