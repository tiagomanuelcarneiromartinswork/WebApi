using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Data
{
    public class WebApiContext : DbContext
    {
        public WebApiContext (DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<Platoon> Platoon { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Allocation> Allocation { get; set; }
    }
}
