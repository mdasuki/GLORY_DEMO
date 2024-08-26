using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CurrentUser
    {
        private static readonly Lazy<CurrentUser> _currentUser = new Lazy<CurrentUser>(() => new CurrentUser());
        private static string Userid = "";


        public static CurrentUser Instance
        {
            get { return _currentUser.Value; }
        }

        protected CurrentUser()
        {
            try
            {
                Userid = "md3234";
            }
            catch
            {
                Userid = "";
            }
        }

        /// <summary>
        /// Gets current user.      
        /// How to use: string currentUser = Helpers.CurrentUser.Instance.GetCurrentUser();
        /// </summary>  
        ///<returns>current user (uswin) as string</returns>

        public string GetCurrentUser()
        {
            return Userid;
        }

    }
}
