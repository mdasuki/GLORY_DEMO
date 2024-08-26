using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGUI.Models
{
    public class PassengerVM
    {
        public List<DTO.PassengerModel> LoadPassengersData()
        {
            DAL.PassengerRepository pr = new();
            var passengers = pr.GetPassengers();
            return passengers;
        }
    }
}
