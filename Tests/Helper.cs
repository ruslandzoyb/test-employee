using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
   public static class Helper
    {
        public static DbContextOptions<EmployeeContext> GetContextInMemory()
        {
            var options = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using (var context = new EmployeeContext(options))
            {
                Seed(context);
            }
            return options;
        }


        public static void Seed(EmployeeContext context)
        {
            context.Positions.AddRange(new Position[]
            {
            new Position()
            {
                Id=1,
                Title="Junior DEV"
            },
            new Position()
            {
                Id=2,
                Title="Senior DEV"
            },
            new Position()
            {
                Id=3,
                Title= "Junior QA"
            }
            });

            context.SaveChanges();
        }



    }
}
