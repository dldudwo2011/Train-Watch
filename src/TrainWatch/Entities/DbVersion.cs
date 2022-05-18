using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainWatch.Entities
{
    public class DbVersion
    {
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Major: {Major}, Minor: {Minor}, Build: {Build}, ReleaseDate: {ReleaseDate}";
        }
    }
}
