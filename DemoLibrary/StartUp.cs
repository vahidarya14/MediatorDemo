using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DemoDAL.Models;
using DemoDAL.DbContexts;
using DemoDAL.Repositories;

namespace DemoCQRS
{
    public class StartUp
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(StartUp).Assembly);
            services.AddScoped<IRepository<PersonEntity>, PersonRepository>();

            services.AddDbContext<IDbContext,DemoDbContext>(options =>options.UseInMemoryDatabase("_MeDb"));
        }
    }
}
