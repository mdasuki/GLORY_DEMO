using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbHelper
    {
        //public DbHelper()
        //{
        //    // connectionString="Data Source=.\reservation.db;Version=3" providerName="System.Data.SqlClient"
        //}
        //public static string LoadConnectionString(string id = "Default")
        //{
        //    return @"Data Source=.\Files\reservation.db";
        //}

        private static readonly Lazy<DbHelper> _connString = new Lazy<DbHelper>(() => new DbHelper());
        private static string ConnString = "";

        public static DbHelper Instance
        {
            get { return _connString.Value; }
        }

        protected DbHelper()
        {
            ConnString = @"Data Source=.\Files\reservation.db";
        }

        /// <summary>
        /// Gets connection string using singleton.      
        /// How to use: string connString = DbHelper.Instance.LoadConnectionString();
        /// </summary>  
        ///<returns>connection string as string</returns>
        public string LoadConnectionString()
        {
            return ConnString;
        }
    }
}
