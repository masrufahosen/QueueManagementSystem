using QMS_Token.Data;
using System.Data;
using System.Data.SqlClient;

namespace QMS.Token.Repo
{
    public class BaseRepo
    {
        protected static DataAccess DataAccess;
        public BaseRepo()
        {
            if (DataAccess == null)
            {
                DataAccess = new DataAccess();
            }
        }

        protected DataTable GetByID(string tableName, int id)
        {
            return GetByColumnNameAndValue(tableName, "Id", id.ToString());
        }

        protected DataTable GetByColumnNameAndValue(string tableName,string columnName, string columnValue)
        {
            string query = "select * from " + tableName + " where "+ columnName + "=@"+ columnName;

            SqlCommand cmd = DataAccess.GetCommand(query);
            cmd.Parameters.AddWithValue("@"+ columnName, columnValue);
            return DataAccess.Execute(cmd);
        }

        protected bool IsExistById(string tableName, int id)
        {
            DataTable dt = GetByID(tableName, id);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        protected DataTable GetAll(string tableName)
        {
            string query = "select * from " + tableName;

            return DataAccess.Execute(query);
        }

        protected DataTable GetLastRow(string tableName,string searchColumnName="Id")
        {
            string query = "select top(1) * from "+ tableName + " order by "+ searchColumnName + " desc";
            return DataAccess.Execute(query);
        }
    }
}
