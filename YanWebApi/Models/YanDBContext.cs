using System;
using Microsoft.EntityFrameworkCore;

namespace YanWebApi.Models
{
    public class YanDBContext : DbContext
    {
        public YanDBContext(DbContextOptions<YanDBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
