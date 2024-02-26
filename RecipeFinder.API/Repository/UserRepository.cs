using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Repository;

public class UserRepository : IRepository
{
  private readonly string _connectionString;

  public UserRepository(string connectionString)
  {
    this._connectionString = connectionString;
  }

  public async Task<IEnumerable<User>> GetAllUsers()
  {
    List<User> Users = new();
    string query = "SELECT * FROM [MVC].[Users]";

    using SqlConnection connection = new(this._connectionString);
    await connection.OpenAsync();
    SqlCommand command = new(query, connection);

    var reader = await command.ExecuteReaderAsync();

    while(await reader.ReadAsync())
    {
      User user = new()
      {
        UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
        UserName = reader.GetString(reader.GetOrdinal("UserName")),
        Email = reader.GetString(reader.GetOrdinal("Email")),
        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
      };
      Users.Add(user);
    }
    return Users;
  }

  public async Task<User?> GetById(int id)
  {
    string query = @"SELECT * FROM [MVC].[Users] WHERE UserID = {@ID}";
    
    using SqlConnection connection = new(this._connectionString);
    SqlCommand command = new(query, connection);
    command.Parameters.AddWithValue("@ID", id);
    var reader = await command.ExecuteReaderAsync();
    
    if (await reader.ReadAsync())
    {
      User user = new(){
        UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
        UserName = reader.GetString(reader.GetOrdinal("UserName")),
        Email = reader.GetString(reader.GetOrdinal("Email")),
        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
      };
      return user;
    }
    else
      return null;
  }

  public async Task AddUser(User user)
  {
    string query = @"INSERT INTO [MVC].[Users] (UserName, Email, CreatedAt) VALUES (@UserName, @Email, @CreatedAt)";

    using SqlConnection connection = new(this._connectionString);
    SqlCommand command = new(query, connection);
    command.Parameters.AddWithValue("@UserName", user.UserName);
    command.Parameters.AddWithValue("@Email", user.Email);
    command.Parameters.AddWithValue("@CreatedAT", user.CreatedAt);

    await command.ExecuteNonQueryAsync();
  }

  public async Task DeleteUser(int id)
  {
    string query = @"DELETE * FROM [MVC].[Users] WHERE UserID = {@UID}";

    using SqlConnection connection = new(this._connectionString);
    SqlCommand command = new(query, connection);
    command.Parameters.AddWithValue("@UID", id);
    await command.ExecuteNonQueryAsync();
  }

}