using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL.Model;
namespace DAL.Repository
{
    public class NotificationsRepository
    {
        //private SqlConnection sqlConnection = null;
        //public void OpenConnection(string connectionString)
        //{
        //    sqlConnection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=NotificationHub;Integrated Security=True" };
        //    sqlConnection.Open();
        //}

        public List<Source> SourceList = new List<Source>();
        //public List<Products> Searchproductslist = new List<Products>();
        public void getDetails()
        {
            
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Data Source=.;Initial Catalog=NotificationHub;Integrated Security=True";

                connection.Open();

                string sql = "select * from Source";
                SqlCommand sqlCommand = new SqlCommand(sql, connection);

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        SourceList.Add(new Source
                        {
                            SourceId = Convert.ToInt32(sqlDataReader["Id"].ToString()),
                            SourceName1 = (sqlDataReader["Name"].ToString()),
                        });
                    }
                }
            }
        }


    }
}
