using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainWatch.DAL;
using TrainWatch.Entities;
using TrainWatch.Collections;

namespace TrainWatch.Services
{
    public class SearchDatabaseService
    {
        public readonly TrainWatchContext _context;
        public SearchDatabaseService(TrainWatchContext context)
        {
            _context = context ?? throw new ArgumentException();
        }

        public int countAllRollingStock()
        {
            return _context.RollingStock.Count();
        }
        public PartialList<RollingStock> GetProducts(string partialReportingMarkName, int skip, int take)
        {
            var items = _context.RollingStock.Where(item => item.ReportingMark.Contains(partialReportingMarkName)).Skip(skip).Take(take);
            var total = _context.RollingStock.Where(item => item.ReportingMark.Contains(partialReportingMarkName)).Count();
            return new PartialList<RollingStock>(total, items.ToList());
        }

        public PartialList<RollingStock> GetProducts(int skip, int take)
        {
            int total = _context.RollingStock.Count();
            var items = _context.RollingStock.Skip(skip).Take(take);
            return new PartialList<RollingStock>(total, items.ToList());
        }
    }
}
