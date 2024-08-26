using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DestinationModel
    {
        public int schedule_id { get; set; }
        public int train_no { get; set; }
        public int route_id { get; set; }
        public int station_id { get; set; }
        public string station_name { get; set; } = "";
        public string station_location { get; set; } = "";
    }
}
