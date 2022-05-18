using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainWatch.DAL;
using TrainWatch.Entities;

namespace TrainWatch.Services
{
    public class AboutServices
    {
        public readonly TrainWatchContext _context;
        public AboutServices(TrainWatchContext context)
        {
            _context = context ?? throw new ArgumentException();
        }

        public DbVersion GetDbVersion()
        {
            return _context.DbVersion.First<DbVersion>();
        }
    }
}
