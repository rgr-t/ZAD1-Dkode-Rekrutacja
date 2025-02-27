using Dapper;
using MyApi.Helpers.Other;
using System.Data;
using System.Data.SqlClient;

namespace MyApi.Repositories.Database
{
    //Simple db service class to connect and query from code using dapper.
    public class DatabaseService : IDatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetDatabaseConnection()
        {
            string databaseConnectionString = _configuration.GetConnectionString(Constants.ConnectionStringDatabaseName);

            return new SqlConnection(databaseConnectionString);
        }
                
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (var connection = GetDatabaseConnection())
            {
                await connection.OpenAsync();
                var queryResult = await connection.QueryAsync<T>(sql, parameters);

                return queryResult;
            }
        }
    }
}