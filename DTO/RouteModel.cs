using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RouteModel
    {
        public int id { get; set; }
        public int source_station_id { get; set; }
        public string source_station_name { get; set; } = "";
        public int destination_station_id { get;set; }
        public string destination_station_name { get; set; } = "";
        public string destination_city { get; set; } = "";
        public string train_no { get; set; } = "";
        public string departure_time { get; set; } = "";
        public string departure_city { get; set; } = "";
    }
}
