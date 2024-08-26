using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StationModel
    {
        public int id {  get; set; }
        public string station_name { get; set; } = "";
        public string location { get; set; } = "";
        public string full_station_name { get; set; } = "";
        public int route_id { get; set; }
    }
}
