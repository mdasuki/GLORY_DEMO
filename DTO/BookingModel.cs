using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookingModel
    {
        public int id { get; set; }
        public int passenger_id { get; set; }
        public int seat_id { get; set; }
        public int schedule_id { get; set; }
        public Int64 booking_date { get; set; }
        public DateTime booking_date_time { get; set; }
    }
}
