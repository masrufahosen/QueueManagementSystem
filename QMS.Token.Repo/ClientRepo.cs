using System.Data;
using System.Data.SqlClient;

namespace QMS.Token.Repo
{
   public class ClientRepo: BaseRepo
    {
        public DataTable GetActiveClientsByServiceId(int serviceId)
        {
            return GetActiveClientsByServiceIdAndStatus(serviceId, 1);
        }
        public DataTable GetInactiveClientsByServiceId(int serviceId)
        {
            return GetActiveClientsByServiceIdAndStatus(serviceId, 0);
        }
        public DataTable GetAllClientsByServiceId(int serviceId)
        {
            DataTable dataTable = new DataTable();
            string sql = "select * From Client where ServiceId=@ServiceId;";
            SqlCommand sqlCommand = DataAccess.GetCommand(sql);
            sqlCommand.Parameters.AddWithValue("@ServiceId", serviceId);
            dataTable = DataAccess.Execute(sqlCommand);
            return dataTable;
        }
        public DataTable GetActiveClientsByServiceIdAndStatus(int serviceId,int status)
        {
            DataTable dataTable = new DataTable();
            string sql = "select * From Client where [Status]=@Status and ServiceId=@ServiceId;";
            SqlCommand sqlCommand = DataAccess.GetCommand(sql);
            sqlCommand.Parameters.AddWithValue("@Status", status);
            sqlCommand.Parameters.AddWithValue("@ServiceId", serviceId);
            dataTable = DataAccess.Execute(sqlCommand);
            return dataTable;
        }
        public int UpdateClientStatus(int status,int Id)
        {
            string updateQuery = "update Client Set Status=@Status where Id=@Id;";
            SqlCommand command = DataAccess.GetCommand(updateQuery);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@Id", Id);
            return DataAccess.ExecuteNonQuery(command);
        }
        public bool ClientLogin(int clientId)
        {
            int affectedRows = UpdateClientStatus(1, clientId);
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }
        public bool ClientLogout(int clientId)
        {
            int affectedRows = UpdateClientStatus(0, clientId);
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }
    }
}
