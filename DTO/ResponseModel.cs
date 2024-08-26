using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResponseModel
    {
        public int id { get; set; }
        public bool success { get; set; }
        public string message { get; set; } = "";
    }
}
