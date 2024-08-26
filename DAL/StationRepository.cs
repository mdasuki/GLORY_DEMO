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
    public class StationRepository
    {
        public List<StationModel> GetDestinationStations(int sourceStationId)
        {
            List<StationModel> stationList = new();
            try
            {
                string sql = @"select t.train_no, sc.departure_time, r.id as route_id, s.id, s.station_name, s.location, 
							t.train_no || ' [departure: ' || sc.departure_time || '] to ' || s.location as full_station_name
                            from stations s inner join routes r on s.id = r.destination_station_id
                            inner join trains t on t.route_id = r.id
                            inner join schedules sc on t.id = sc.train_id
                            where s.id != @source_station_id";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    stationList = con.Query<StationModel>(sql, new {source_station_id = sourceStationId}).ToList();
                }
            }
            catch (Exception ex)
            {
                // throw error and log it
            }

            return stationList;
        }
    }
}
