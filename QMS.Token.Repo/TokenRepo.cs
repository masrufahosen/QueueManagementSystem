
using System;
using System.Data;
using System.Data.SqlClient;

namespace QMS.Token.Repo
{
    public class TokenRepo: BaseRepo
    {
        public TokenRepo()
        {

        }
        
        public DataTable GetLastTokenForToday()
        {
            DataTable lastToken = new DataTable();
            string queryToGetLastToken = "Select top(1) * From Token  where CreationTime>@CreationTime order by CreationTime desc";
            SqlCommand command = DataAccess.GetCommand(queryToGetLastToken);
            command.Parameters.AddWithValue("@CreationTime", DateTime.Today);
            lastToken = DataAccess.Execute(command);
            var tokenNumber = lastToken.Columns["TokenNumber"];
            
            return lastToken;
        }
        public DataTable GetTodaysWaitingTokenbyClient(int clientId)
        {
            DataTable tokens = new DataTable();
            string queryToGetLastToken = "Select * From Token  where CreationTime>@CreationTime " +
                "and ClientId=@ClientId and IsServiceProvided=@IsServiceProvided " +
                "and IsCalled=@IsCalled order by CreationTime asc";
            SqlCommand command = DataAccess.GetCommand(queryToGetLastToken);
            command.Parameters.AddWithValue("@CreationTime", DateTime.Today);
            command.Parameters.AddWithValue("@ClientId", clientId);
            command.Parameters.AddWithValue("@IsServiceProvided", 0);
            command.Parameters.AddWithValue("@IsCalled", 0);
            tokens = DataAccess.Execute(command);
            return tokens;
        }
        public DataTable GetTodaysTokensByServiceProvidedStatusAndCalledStatus(int serviceProvidedStatus,int tokenCalledStatus)
        {
            DataTable tokens = new DataTable();
            string queryToGetTokens = "Select CONCAT(LEFT(Service.Name, 1), '',TokenNumber ) AS 'Token Number', CreationTime " +
                "From Token,Service  where Token.ServiceId=[Service].Id  " +
                "and CreationTime>@CreationTime and IsServiceProvided=@IsServiceProvided " +
                "and IsCalled=@IsCalled order by CreationTime asc";
            SqlCommand command = DataAccess.GetCommand(queryToGetTokens);
            command.Parameters.AddWithValue("@CreationTime", DateTime.Today);
            command.Parameters.AddWithValue("@IsServiceProvided", serviceProvidedStatus);
            command.Parameters.AddWithValue("@IsCalled", tokenCalledStatus);
            tokens = DataAccess.Execute(command);
            return tokens;
        }
        public DataTable GetTodaysNextTokenbyClientId(int clientId)
        {
            DataTable tokens = new DataTable();
            string queryToGetLastToken = "Select Top(1) Token.Id,TokenNumber,Name From Token,Service  where CreationTime>@CreationTime and ClientId=@ClientId and IsServiceProvided=@IsServiceProvided and IsCalled=@IsCalled and ServiceId=Service.Id order by CreationTime asc";
            SqlCommand command = DataAccess.GetCommand(queryToGetLastToken);
            command.Parameters.AddWithValue("@CreationTime", DateTime.Today);
            command.Parameters.AddWithValue("@ClientId", clientId);
            command.Parameters.AddWithValue("@IsServiceProvided", 0);
            command.Parameters.AddWithValue("@IsCalled", 0);
            tokens = DataAccess.Execute(command);
            return tokens;
        }

        public DataTable GetTodaysNextToken()
        {
            string queryToGetLastToken = "Select Top(1) Token.Id,TokenNumber,Name From Token,Service  where CreationTime>@CreationTime and IsServiceProvided=@IsServiceProvided and IsCalled=@IsCalled and ServiceId=Service.Id order by CreationTime asc";
            SqlCommand command = DataAccess.GetCommand(queryToGetLastToken);
            command.Parameters.AddWithValue("@CreationTime", DateTime.Today);
            command.Parameters.AddWithValue("@IsServiceProvided", 0);
            command.Parameters.AddWithValue("@IsCalled", 1);

            return DataAccess.Execute(command);
        }

        public int UpdateTokenAfterCall(int TokenId, int serviceStatus,int callingStatus,DateTime ServiceProvidedAt)
        {
            string updateQuery = "update Token SET ServiceProvidedAt=@ServiceProvidedAt, IsServiceProvided=@IsServiceProvided,IsCalled=@IsCalled where Id=@Id;";
            SqlCommand command = DataAccess.GetCommand(updateQuery);
            command.Parameters.AddWithValue("@Id", TokenId);
            command.Parameters.AddWithValue("@IsServiceProvided", serviceStatus);
            command.Parameters.AddWithValue("@IsCalled", callingStatus);
            command.Parameters.AddWithValue("@ServiceProvidedAt", ServiceProvidedAt);
            DataAccess.ExecuteNonQuery(command);
            return 0;
        }
        public int ServiceProvidedToToken(int tokenId)
        {
            return UpdateTokenAfterCall(tokenId, 1, 1, DateTime.Now);
        }
        public int UpdateTokenCalledStatus(int tokenId)
        {
            return UpdateTokenAfterCall(tokenId, 0, 1, DateTime.Parse("1/1/1900"));
        }
        public int UpdateTokenCalledStatusToPassed(int tokenId)
        {
            return UpdateTokenAfterCall(tokenId, 0, 2, DateTime.Parse("1/1/1900"));
        }
        public bool InsertToken(int tokenNumber,int serviceId,int clientId)
        {
            string insertQuery = "insert into Token (TokenNumber,CreationTime,ServiceId,ClientId,IsCalled,IsServiceProvided) " +
                "Values(@TokenNumber, @CreationTime,@ServiceId,@ClientId,@IsCalled,@IsServiceProvided)";
            var command = DataAccess.GetCommand(insertQuery);
            command.Parameters.AddWithValue("@TokenNumber",tokenNumber);
            command.Parameters.AddWithValue("@CreationTime", DateTime.Now);
            command.Parameters.AddWithValue("@ServiceId", serviceId);
            command.Parameters.AddWithValue("@ClientId", clientId);
            command.Parameters.AddWithValue("@IsCalled", 0);
            command.Parameters.AddWithValue("@IsServiceProvided", 0);
            int affectedRows= DataAccess.ExecuteNonQuery(command);
            if (affectedRows > 0)
            {
                return true;
            }
            return false;
        }

    }
}
