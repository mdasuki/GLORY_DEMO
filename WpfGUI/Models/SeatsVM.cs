using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGUI.Models
{
    public class SeatsVM
    {
        public List<DTO.SeatModel> LoadSeatsData(int routeId)
        {
            DAL.SeatRepository sr = new();
            var seats = sr.getSeats(routeId);
            return seats;
        }
        public DTO.ResponseModel AssignSeat(int routeId, string seatNumber)
        {
            DAL.SeatRepository sr = new();
            DTO.SeatModel seat = sr.getSeat(routeId, seatNumber);
            DTO.ResponseModel res = sr.BookSeat(seat.id);
            return res;
        }
    }
}
