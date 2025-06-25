using MySql.Data.MySqlClient;
using System.Data;

public class DapperContext
{
    private static readonly string _connectionString = "Server=localhost;Database=local;User Id=root;Password=Root@123;";
    public static IDbConnection CreateConnection()
        => new MySqlConnection(_connectionString);
}