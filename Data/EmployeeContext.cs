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
            Surname="Trikoz",
             
            }
            });
            
        }
        
    }
}