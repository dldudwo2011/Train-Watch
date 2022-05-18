using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainWatch.Entities;


namespace TrainWatch.DAL
{
    public class TrainWatchContext : DbContext 
    {
        public TrainWatchContext(DbContextOptions<TrainWatchContext> options) : base(options)
        {

        }

        public DbSet<DbVersion> DbVersion { get; set; }
        public DbSet<RailCarType> RailCarTypes { get; set; }
        public DbSet<RollingStock> RollingStock { get; set; }
    }
}
