using System.Data;

namespace MyApi.Repositories.Database
{
    public interface IDatabaseService
    {        
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text);        
    }
}