using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext myDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                //if (!myDbContext.Customers.Any()))
                //{
                //    myDbContext.Customers.AddRange(GetPreconfiguredCustomers());

                //    await myDbContext.SaveChangesAsync();
                //}

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ApplicationDbContext>();
                    log.LogError(ex.Message);
                    await SeedAsync(myDbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Customer> GetPreconfiguredCustomers()
        {
            return new List<Customer>()
            {
                new Customer() {Id=1}
            };
        }
    }
}
