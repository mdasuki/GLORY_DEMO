using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrainModel
    {
        public int id {  get; set; }
        public string train_no { get; set; } = "";
        public string train_name { get; set; } = "";
        public int route_id { get; set; }
    }
}
