using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.PL.Tests
{
   internal class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveEmployeeContextRegistration(services);

                var serviceProvider = GetInMemoryServiceProvider();

                services.AddDbContextPool<EmployeeContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.Empty.ToString());
                    options.UseInternalServiceProvider(serviceProvider);
                });

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<EmployeeContext>();

                    Helper.Seed(context);
                }
            });
        }

        private static ServiceProvider GetInMemoryServiceProvider()
        {
            return new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
        }

        private static void RemoveEmployeeContextRegistration(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<EmployeeContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }


    }
}
