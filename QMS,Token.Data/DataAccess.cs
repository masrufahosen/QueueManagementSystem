using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace QMS_Token.Data
{
    public class DataAccess
    {


        public static string ConnectionString
        {
            get;private set;
        }

        public DataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DataAccess()
        {
            ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mou\source\repos\QMS.Token.Generate.WindowsClient\QMSDB.mdf;Integrated Security=True;Connect Timeout=30";
        }

        /// <summary>
        /// Returns a SqlCommand object to add some parameters in it. After you send this to Execute method.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlCommand GetCommand(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            return sqlCmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Execute(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = GetCommand(sql);

            cmd.Connection.Open();
            dt.Load(cmd.ExecuteReader());
            cmd.Connection.Close();
            return dt;
        }

        /// <summary>
        /// Returns DataTable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable Execute(SqlCommand command)
        {
            DataTable dt = new DataTable();

            command.Connection.Open();
            dt.Load(command.ExecuteReader());
            command.Connection.Close();

            return dt;
        }

        /// <summary>
        /// returns affected row count
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = GetCommand(sql);
            int result = 0;
            cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand command)
        {
            int result = 0;
            command.Connection.Open();
            result = command.ExecuteNonQuery();
            command.Connection.Close();
            return result;
        }

    }
}
