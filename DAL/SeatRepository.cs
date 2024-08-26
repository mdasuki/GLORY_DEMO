using Dapper;
using DTO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SeatRepository
    {
        public List<SeatModel> getSeats(int routeId)
        {
            List<SeatModel> seats = new();
            try
            {
                string sql = @"select s.id, s.seat_number, s.is_available
                            from seats s inner join trains t on s.train_id = t.id 
                            inner join routes r on t.route_id = r.id
                            where r.id = @route_id
                            order by s.seat_number ";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    seats = con.Query<SeatModel>(sql, new { route_id = routeId }).ToList();
                }
            }
            catch (Exception ex)
            {
                // if error, log it
            }
            return seats;
        }
        public SeatModel getSeat(int routeId, string seatNumber)
        {
            SeatModel seat = new();
            try
            {
                string sql = @"select s.id, s.seat_number, s.is_available 
                            from trains t inner join seats s on t.id = s.train_id
                            where t.route_id = @route_id and s.seat_number = @seat_number";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    seat = con.Query<SeatModel>(sql, new { route_id = routeId, seat_number = seatNumber }).FirstOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                // if error log it.
            }
            return seat;
        }
        public ResponseModel BookSeat(int seatId)
        {
            ResponseModel response = new ResponseModel();
            response.id = seatId;
            try
            {
                int cnt = 0;
                string sql = "update seats set is_available = 0 where id = @seatid";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    cnt = con.Execute(sql, new {seatid = seatId});
                }
                if (cnt > 0)
                {
                    response.success = true;
                }
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return response;
        }
    }
}
