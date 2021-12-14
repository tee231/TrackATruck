using TrackATruckMgt.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Infrstructure.Configurations;
using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Users;

namespace TrackATruckMgt.Data
{
    public class APPContext : DbContext
    {

    public APPContext(DbContextOptions<APPContext> options): base(options)
     {
    
     }

        public DbSet<DriverDto> Drivers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SeedingConfigurations());
            //base.OnModelCreating(builder);
            // IndexFields(builder);
        }
    }

}
