namespace DataAccessLayer.DapperContext;

using System.Data;
using MySql.Data.MySqlClient;
public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext()
    {
        _connectionString = "Server=localhost;Database=local;User Id=root;Password=Root@123;";
    }

    public IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}
