using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SeatModel
    {
        public int id { get; set; }
        public string seat_number { get; set; } = "";
        public int is_available { get; set; }
        public int train_id { get; set; }
    }
}
