using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularStarted.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularStarted.Data
{
    public class EmpleatContext : DbContext
    {

        public EmpleatContext(DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Empleat> Empleats { get; set; }

    }
}
