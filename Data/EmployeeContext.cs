using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        

        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().HasData(new Employee[]
            {
    new Employee()
         {
            Id=1,
            Name="Ruslan",
            Surname="Dzobko",
            
        }, 

            new Employee()
            {
                Id=2,
            Name="Alina",
            Surname="Trykoz",
             
            },
             new Employee()
            {
                Id=3,
            Name="Max",
            Surname="Maluk",

            }

            });

            builder.Entity<Position>().HasData(new Position[] {
            new Position()
            {
                Id=1,
                Title="Dev"
            },
            new Position()
            {
                Id=2,
                Title="QA",
            },
            new Position()
            {
                Id=3,
                Title="BA",
            },
            new Position()
            {
                Id=4,
                Title="Manager",
            }
            });




            builder.Entity<EmployeePosition>().HasData(new EmployeePosition[]
            {
                new EmployeePosition()
                {
                    Id=1,
                    EmployeeId=2,
                    PositionId=4,
                    Salary=1000,
                    Hired=new DateTime(2017,5,13)


                },
                 new EmployeePosition()
                {
                    Id=2,
                    EmployeeId=1,
                    PositionId=1,
                    Salary=2500,
                    Hired=new DateTime(2020,9,11)


                },
                  new EmployeePosition()
                {
                    Id=3,
                    EmployeeId=2,
                    PositionId=3,
                    Salary=800,
                    Hired=new DateTime(2016,3,21),
                    Fired=new DateTime(2017,1,11)


                },
                  new EmployeePosition()
                {
                    Id=4,
                    EmployeeId=3,
                    PositionId=2,
                    Salary=1300,
                    Hired=new DateTime(2018,10,4),
                    


                }

            });


            
        }
        
    }
}