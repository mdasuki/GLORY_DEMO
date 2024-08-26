using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ScheduleModel
    {
        public int id {  get; set; }
        public int train_id { get; set; }
        public string departure_time { get; set; } = "";
    }
}
