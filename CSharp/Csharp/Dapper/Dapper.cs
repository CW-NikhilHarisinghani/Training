using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Dapper
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Order> Orders { get; set; } = new();

        public override string ToString()
        {
            return $"User(Id: {Id}, Name: {Name}, Age: {Age})";
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Product { get; set; }

        public override string ToString()
        {
            return $"Order(OrderId: {OrderId}, Product: {Product})";
        }
    }

    class DapperExample
    {
        public static async Task Run()
        {
            string connectionString = "Server=localhost;Database=local;User Id=root;Password=Root@123;SslMode=None;";
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            Console.WriteLine("Connected to MySQL.");

            // 1. Create tables
            await connection.ExecuteAsync(@"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Name VARCHAR(100),
                    Age INT
                );

                CREATE TABLE IF NOT EXISTS Orders (
                    OrderId INT AUTO_INCREMENT PRIMARY KEY,
                    UserId INT,
                    Product VARCHAR(100),
                    FOREIGN KEY (UserId) REFERENCES Users(Id)
                );
            ");

            // 2. Insert data
            await connection.ExecuteAsync("INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", new { Name = "Nikhil", Age = 23 });

            // 3. Update data
            await connection.ExecuteAsync("UPDATE Users SET Age = @Age WHERE Name = @Name", new { Name = "Nikhil", Age = 24 });

            // 4. Delete data
            await connection.ExecuteAsync("DELETE FROM Users WHERE Name = @Name", new { Name = "ToDelete" });

            // 5. Transaction example
            using var transaction = await connection.BeginTransactionAsync();
            try
            {
                await connection.ExecuteAsync("INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", new { Name = "Alice", Age = 30 }, transaction);
                await connection.ExecuteAsync("INSERT INTO Users (Name, Age) VALUES (@Name, @Age)", new { Name = "Bob", Age = 25 }, transaction);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }

            // 6. Insert orders for join demo
            await connection.ExecuteAsync("INSERT INTO Orders (UserId, Product) VALUES (@UserId, @Product)", new { UserId = 1, Product = "Book" });
            await connection.ExecuteAsync("INSERT INTO Orders (UserId, Product) VALUES (@UserId, @Product)", new { UserId = 1, Product = "Pen" });

            // 7. One-to-many mapping with splitOn
            var sql = @"
                SELECT u.Id, u.Name, u.Age, o.OrderId, o.Product
                FROM Users u
                LEFT JOIN Orders o ON u.Id = o.UserId";

            var userDict = new Dictionary<int, User>();

            var users = await connection.QueryAsync<User, Order, User>(
                sql,
                (user, order) =>
                {
                    if (!userDict.TryGetValue(user.Id, out var currentUser))
                    {
                        currentUser = user;
                        userDict.Add(currentUser.Id, currentUser);
                    }
                    if (order != null)
                        currentUser.Orders.Add(order);
                    return currentUser;
                },
                splitOn: "OrderId"
            );

            foreach (var user in users.Distinct())
            {
                Console.WriteLine($"User: {user.Name} ({user.Age})");
                foreach (var order in user.Orders)
                {
                    Console.WriteLine($"  Order: {order.Product}");
                }
            }

            var query = "select * from Users, Orders where Users.Id = Orders.UserId";
            var res = await connection.QueryAsync(query);  
            foreach (var item in res)
            {
                Console.WriteLine(item.Name + " - " + item.Product);
            }
            Console.WriteLine("Query executed successfully.");
        }
    }
}
