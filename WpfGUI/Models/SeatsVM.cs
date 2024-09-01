using DAL;

namespace WpfGUI.Models
{
    public class SeatsVM
    {
        private readonly ISeatRepository _seat;

        public SeatsVM(ISeatRepository seat)
        {
            _seat = seat;
        }
        public List<DTO.SeatModel> LoadSeatsData(int routeId)
        {
            //DAL.SeatRepository sr = new();
            var seats = _seat.getSeats(routeId);
            return seats;
        }
        public DTO.ResponseModel AssignSeat(int routeId, string seatNumber)
        {
            //DAL.SeatRepository sr = new();
            DTO.SeatModel seat = _seat.getSeat(routeId, seatNumber);
            DTO.ResponseModel res = _seat.BookSeat(seat.id);
            return res;
        }
    }
}
