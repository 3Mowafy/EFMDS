using Microsoft.Data.SqlClient;

namespace EFMDS.Web.Helpers;

public class SqlHelper
{
    private readonly string _connectionString;
    public SqlHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<List<T>> ExecuteQueryAsync<T>(
        string sql,
        Func<SqlDataReader, T> map,
        Action<SqlParameterCollection>? paramBuilder = null)
    {
        var results = new List<T>();

        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);

        paramBuilder?.Invoke(command.Parameters);

        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            results.Add(map(reader));
        }
        return results;
    }

    public async Task<T?> ExecuteSingleAsync<T>(string sql, Func<SqlDataReader, T> map,
        Action<SqlParameterCollection>? paramBuilder = null)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);
        paramBuilder?.Invoke(command.Parameters);

        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return map(reader);
        }
        return default;
    }

    public async Task<object?> ExecuteScalarAsync(string sql,
     Action<SqlParameterCollection>? paramBuilder = null)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);
        paramBuilder?.Invoke(command.Parameters);

        return await command.ExecuteScalarAsync();
    }

    public async Task<int> ExecuteNonQueryAsync(string sql,
     Action<SqlParameterCollection>? paramBuilder = null)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new SqlCommand(sql, connection);
        paramBuilder?.Invoke(command.Parameters);

        return await command.ExecuteNonQueryAsync();
    }
}