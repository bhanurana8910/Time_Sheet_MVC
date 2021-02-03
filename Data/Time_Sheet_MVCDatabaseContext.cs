using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Time_Sheet_MVC.Models;

namespace Time_Sheet_MVC.Models
{
    //Connects the  models to the underlying database tables.
    public class Time_Sheet_MVCDatabaseContext : DbContext
    {
        public Time_Sheet_MVCDatabaseContext (DbContextOptions<Time_Sheet_MVCDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Time_Sheet_MVC.Models.Department> Department { get; set; }

        public DbSet<Time_Sheet_MVC.Models.Employee> Employee { get; set; }

        public DbSet<Time_Sheet_MVC.Models.TimeRecord> TimeRecord { get; set; }
    }
}
