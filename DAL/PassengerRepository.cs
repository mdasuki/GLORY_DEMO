using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;
using DTO;
using System.Collections.Generic;
using System.Diagnostics;

namespace DAL
{
    public class PassengerRepository
    {
        public List<PassengerModel> GetPassengers()
        {
            List<PassengerModel> pasList = new List<PassengerModel>();
            try
            {
                string sql = "select id, first_name, last_name, first_name || ' ' || last_name as full_name, email, phone from passengers order by full_name";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    pasList = con.Query<PassengerModel>(sql, new DynamicParameters()).ToList();
                }
            }
            catch(Exception ex) 
            {
                // throw error and log it
            }

            return pasList; 
        }
        public PassengerModel GetPassenger(string phoneNumber) 
        {
            PassengerModel passenger = new PassengerModel();
            try
            {
                string sql = "select id, first_name, last_name, first_name + ' ' + last_name as full_name email, phone from passengers where phone = @phonenum";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    passenger = con.Query<PassengerModel>(sql, new { phonenum = phoneNumber }).FirstOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                // throw error and log it
            }
            return new PassengerModel();
        }
        public PassengerModel InsertPassenger(PassengerModel passenger)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int cnt = 0;
                string sql = "insert into passengers (id, first_name, last_name, email, phone) value (id, first_name, last_name, email, phone)";
                using (IDbConnection con = new SqliteConnection(DbHelper.Instance.LoadConnectionString()))
                {
                    cnt = con.Execute(sql, passenger);
                }
                if (cnt > 0)
                {
                    response.id = 1;
                    response.success = true;
                }
            }
            catch (Exception ex)
            {
                // throw error and log it
            }
            return new PassengerModel();
        }
    }
}
