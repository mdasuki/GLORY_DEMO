using DTO;

namespace DAL
{
    public interface ISeatRepository
    {
        ResponseModel BookSeat(int seatId);
        SeatModel getSeat(int routeId, string seatNumber);
        List<SeatModel> getSeats(int routeId);
    }
}