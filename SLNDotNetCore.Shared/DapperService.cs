using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace SLNDotNetCore.Shared
{
    public class DapperService
    {
        string _connectionString;
        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T>Query<T>(string query,object? param = null)
        {
            using IDbConnection dbCon = new SqlConnection(_connectionString);
            var list = dbCon.Query<T>(query,param).ToList();
            return list;
        }
        public T QueryFirstOrDefault<T>(string query,object? param = null)
        {
            using IDbConnection dbCon = new SqlConnection(_connectionString);
            var result = dbCon.Query<T>(query, param).FirstOrDefault();
            return result;
        }
        public int Execute(string query, object? param = null)
        {
            using IDbConnection dbCon = new SqlConnection(_connectionString);
            int result = dbCon.Execute(query,param);
            return result;
        }
    }
}
