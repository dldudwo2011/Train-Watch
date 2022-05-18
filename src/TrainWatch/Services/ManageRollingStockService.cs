using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainWatch.DAL;
using TrainWatch.Entities;
using TrainWatch.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TrainWatch.Services
{
    public class ManageRollingStockService
    {
        public readonly TrainWatchContext _context;
        public ManageRollingStockService(TrainWatchContext context)
        {
            _context = context ?? throw new ArgumentException();
        }

        public List<RailCarType> ListRailCarTypes()
        {
            return _context.RailCarTypes.ToList();
        }
        public RollingStock FindRollingStockWithReportingMark(string reportingMark)
        {
            return _context.RollingStock.Find(reportingMark);
        }

        public string AddRailCar(RollingStock rollingStock)
        {
            _context.RollingStock.Add(rollingStock);
            _context.SaveChanges();
            return rollingStock.ReportingMark;
        }

        public void UpdateRailCar(RollingStock rollingStock)
        {
            var existing = _context.Entry(rollingStock);
            existing.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRailCar(RollingStock rollingStock)
        {
            var existing = _context.Entry(rollingStock);
            existing.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
