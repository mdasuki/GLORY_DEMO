using Dapper;
using DTO;
using Microsoft.Data.Sqlite;
using System.Data;

namespace DAL
{
    public class RouteRepository : IRouteRepository
    {
        public RouteModel getRouteDetails(int routeId)
        {
            RouteModel route = new();
            try
            {
                string sql = @"select r.id, t.train_no, s.location as destination_city, sc.departure_time,
                                (select s2.location from stations s2 where s2.id = r.source_station_id) as departure_city
                                from stations s inner join routes r on s.id = r.destination_station_id
                                inner join trains t on t.route_id = r.id
                                inner join schedules sc on t.id = sc.train_id
                                where r.id = @route_id";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    route = con.Query<RouteModel>(sql, new { route_id = routeId }).FirstOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                // throw error and log it
            }
            return route;
        }
    }
}
