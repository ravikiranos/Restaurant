using DAL;
using DataContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BLUserResgistration
    {
        DCUserResgistration dcBLUserResgistration = new DCUserResgistration();
        DatabaseHelper dbHelper = null;
        public List<DCUserResgistration> GetUsersSample(int intUserId)
        {
            List<DCUserResgistration> lstUserResgistration = null;
            //lstUserResgistration = new List<DCUserResgistration>();
            //lstUserResgistration.Add(new DCUserResgistration { UserID = 1, FirstName = "Ravi" });
            //lstUserResgistration.Add(new DCUserResgistration { UserID = 2, FirstName = "Rajesh" });
            DCUserResgistration dcUserResgistration = null;
            try
            {
                dbHelper = new DatabaseHelper();
                dbHelper.AddParameter("UserId", intUserId == 0 ? 0 : intUserId);
                DbDataReader reader = dbHelper.ExecuteReader("select UserId, FirstName from user", CommandType.Text);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dcUserResgistration = new DCUserResgistration();
                        dcUserResgistration.UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? 0 : reader.GetInt32(reader.GetOrdinal("UserID"));
                        dcUserResgistration.FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? string.Empty : reader.GetString(reader.GetOrdinal("FirstName"));
                        lstUserResgistration.Add(dcUserResgistration);
                    }
                }
            }
            catch (Exception excp)
            {
                //log your exception
            }
            finally
            {
                dbHelper.Dispose();
            }
            return lstUserResgistration;
        }

        public string InsertUpdateUsersSample(DCUserResgistration dCUserResgistration)
        {
            string dbResponse = string.Empty;
            try
            {
                dbHelper = new DatabaseHelper();
                dbHelper.AddParameter("UserId", dcBLUserResgistration.UserID);
                int intResponse = dbHelper.ExecuteNonQuery("insert query", CommandType.Text);
            }
            catch (Exception excp)
            {

                //log your exception
            }
            finally
            {
                dbHelper.Dispose();
            }
            return dbResponse;
        }
    }
}
