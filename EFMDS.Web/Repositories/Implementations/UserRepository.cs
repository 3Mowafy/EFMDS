using EFMDS.Web.Models;
using EFMDS.Web.Helpers;
using EFMDS.Web.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EFMDS.Web.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly SqlHelper _sqlHelper;

    public UserRepository(SqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
    }

    public Task<List<User>> GetAllAsync()
    {
        string sql = "SELECT Id, FullName, Email, PasswordHash, Phone, RoleId, IsActive, CreatedAt FROM Users";
        return _sqlHelper.ExecuteQueryAsync(sql, Map);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        string sql = "SELECT Id, FullName, Email, PasswordHash, Phone, RoleId, IsActive, CreatedAt FROM Users WHERE Id = @Id";
        return _sqlHelper.ExecuteSingleAsync(sql, Map,
            p => p.Add("@Id", SqlDbType.Int).Value = id);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        string sql = "SELECT Id, FullName, Email, PasswordHash, Phone, RoleId, IsActive, CreatedAt FROM Users WHERE Email = @Email";
        return _sqlHelper.ExecuteSingleAsync(sql, Map,
            p => p.Add("@Email", SqlDbType.NVarChar, 150).Value = email);
    }

    public async Task<User> AddAsync(User user)
    {
        string sql = @"INSERT INTO Users (FullName, Email, PasswordHash, Phone, RoleId, IsActive, CreatedAt)
                       VALUES (@FullName, @Email, @PasswordHash, @Phone, @RoleId, @IsActive, @CreatedAt);
                       SELECT SCOPE_IDENTITY();";

        var newId = await _sqlHelper.ExecuteScalarAsync(sql, p =>
        {
            p.Add("@FullName", SqlDbType.NVarChar, 100).Value = user.FullName;
            p.Add("@Email", SqlDbType.NVarChar, 150).Value = user.Email;
            p.Add("@PasswordHash", SqlDbType.NVarChar, 256).Value = user.PasswordHash;
            p.Add("@Phone", SqlDbType.NVarChar, 20).Value = (object?)user.Phone ?? DBNull.Value;
            p.Add("@RoleId", SqlDbType.Int).Value = user.RoleId;
            p.Add("@IsActive", SqlDbType.Bit).Value = user.IsActive;
            p.Add("@CreatedAt", SqlDbType.DateTime2).Value = user.CreatedAt;
        });

        user.Id = Convert.ToInt32(newId);
        return user;
    }

    public async Task<User?> UpdateAsync(User user)
    {
        string sql = @"UPDATE Users 
                       SET FullName = @FullName, Phone = @Phone
                       WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p =>
        {
            p.Add("@Id", SqlDbType.Int).Value = user.Id;
            p.Add("@FullName", SqlDbType.NVarChar, 100).Value = user.FullName;
            p.Add("@Phone", SqlDbType.NVarChar, 20).Value = (object?)user.Phone ?? DBNull.Value;
        });

        return rows > 0 ? user : null;
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        string sql = "UPDATE Users SET IsActive = 0 WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql,
            p => p.Add("@Id", SqlDbType.Int).Value = id);

        return rows > 0;
    }

    private static User Map(SqlDataReader reader) =>
        new()
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            FullName = reader.GetString(reader.GetOrdinal("FullName")),
            Email = reader.GetString(reader.GetOrdinal("Email")),
            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
            RoleId = reader.GetInt32(reader.GetOrdinal("RoleId")),
            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
        };
}