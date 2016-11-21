using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CityTravelService.Models
{
    public class DataProvider
    {
        //private string _connectString = @"Data Source=HAMINHDAT\SQLEXPRESS;Initial Catalog=CityTravel;Integrated Security=True";
        protected static string _connectionString;

        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;


        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public void connect()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public void disconnect()
        {
            connection.Close();
        }

        public IDataReader executeQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteReader();
        }

        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();
        }

        public object executeScalar(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteScalar();
        }

        protected ArrayList ConvertDataSetToArrayList(DataSet dataset)
        {
            ArrayList arr = new ArrayList();
            DataTable dt = dataset.Tables[0];
            int i, n = dt.Rows.Count;
            for (i = 0; i < n; i++)
            {
                object obj = GetDataFromDataRow(dt, i);
                arr.Add(obj);

            }
            return arr;
        }

        protected virtual object GetDataFromDataRow(DataTable dt, int i)
        {
            return null;
        }

    }
}