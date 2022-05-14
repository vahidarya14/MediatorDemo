using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DemoDAL.Models;
using DemoDAL.DbContexts;
using DemoDAL.Repositories;
using DemoCQRS.PipelineBehaviors;
using DemoCQRS.Queries;
using System.Collections.Generic;

namespace DemoCQRS
{
    public class StartUp
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(StartUp).Assembly);
            services.AddScoped<IRepository<PersonEntity>, PersonRepository>();

            services.AddDbContext<IDbContext,DemoDbContext>(options =>options.UseInMemoryDatabase("_MeDb"));

   
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

        }
    }
}
