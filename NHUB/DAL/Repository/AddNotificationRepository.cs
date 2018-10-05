using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace DAL.Repository
{
    public class AddNotificationRepository
    {

        public int InsertEvent(string Name, int Sourceid,bool Confidential, bool Mandetory)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Connections.Constring;
            connection.Open();
            // Note the "placeholders" in the SQL query.
            string sql = "Insert Into Event" +
                                "(Name, SourceId,Mandatory,Confidential) Values" +
                                "(@Name, @Sourceid,@Mandatory,@Confidential)";


            // This command will have internal parameters.
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Fill params collection.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = Name,
                    SqlDbType = SqlDbType.Char,
                    Size = 30
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Sourceid",
                    Value = Sourceid,
                    SqlDbType = SqlDbType.Int,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Mandatory",
                    Value = Mandetory,
                    SqlDbType = SqlDbType.Bit,
                    Size = 1
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Confidential",
                    Value = Confidential,
                    SqlDbType = SqlDbType.Bit,
                    Size = 1
                };
                command.Parameters.Add(parameter);


                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Cant insert Data!", ex);
                    throw error;
                }
            }

            string str = "select max(Id) from event";
            SqlCommand sqlCommand = new SqlCommand(str, connection);
            int y = Convert.ToInt32(sqlCommand.ExecuteScalar());
            connection.Close();
            return y;
        }
        public void InsertEventChannel(long id, int channelid)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Connections.Constring;
            connection.Open();
            // Note the "placeholders" in the SQL query.
            string sql = "Insert Into EventChannel" +
                                "(EventId, ChannelId) Values" +
                                "(@Eventid, @Channelid)";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Fill params collection.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Eventid",
                    Value = id,
                    SqlDbType = SqlDbType.Int,
                    Size = 30
                };
                command.Parameters.Add(parameter);
                parameter = new SqlParameter
                {
                    ParameterName = "@Channelid",
                    Value = channelid,
                    SqlDbType = SqlDbType.Int,
                    Size = 30
                };
                command.Parameters.Add(parameter);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Cant insert Data!", ex);
                    throw error;
                }
            }
        }
        public DataSet GetEventData(int Sourceid)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Connections.Constring;

                connection.Open();
                if (Sourceid > 0)
                {
                    string sql = "select * from event where Sourceid=" + Sourceid;
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else
                {
                    string sql = "select * from event";
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        public DataSet EventChannelGetData(int id)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Connections.Constring;

                connection.Open();

                string sql = "select distinct (ChannelId),* from EventChannel where EventId=" + id;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }



        public void DeleteData(int EventId)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Connections.Constring;
                connection.Open();
                string  sql = "Delete from EventChannel where EventId=" + EventId;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                // SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
                sql = "Delete from Event where Id=" + EventId;
                sqlCommand = new SqlCommand(sql, connection);
                // SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void DeleteChannel(int eventid)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Connections.Constring;

                connection.Open();

                string sql = "Delete from EventChannel where EventId=" + eventid;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                // SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void UpdateEventData(int EventId,string name,bool Maandetory,bool Confidential)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Connections.Constring;

                connection.Open();

                string sql = $"Update event set Name='{name}', Mandatory='{Maandetory}', Confidential='{Confidential}'where Id=" + EventId;
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                // SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Connections.Constring))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }

       


    }
    }

