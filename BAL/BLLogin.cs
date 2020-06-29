using DAL;
using DataContract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public  class BLLogin
    {

        public string AuthenticateUser(DCLogin dCLogin)
        {
            string response = string.Empty;
            string SqlQuery = string.Empty;
            DatabaseHelper databaseHelper = null;
            try
            {
                databaseHelper = new DatabaseHelper();
                SqlQuery = "Select UserName from AspNetUsers where Email = '" + dCLogin.Email + "'  and PasswordHash = '" + dCLogin.PasswordHash + "'";
                response =Convert.ToString(databaseHelper.ExecuteScalar(SqlQuery,System.Data.CommandType.Text));
            }
            catch(Exception ex)
            {

                response = ex.Message.ToString();
            }
            finally
            {
                databaseHelper.Dispose();


            }
            return response;
                 
        }
    }
}
