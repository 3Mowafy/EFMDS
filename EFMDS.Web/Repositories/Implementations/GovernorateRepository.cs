using EFMDS.Web.Models;
using EFMDS.Web.Helpers;
using EFMDS.Web.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EFMDS.Web.Repositories.Implementations;

public class GovernorateRepository : IGovernorateRepository
{
    private readonly SqlHelper _sqlHelper;
    public GovernorateRepository(SqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
    }

    public Task<List<Governorate>> GetAllAsync()
    {
        string sql = "SELECT Id, NameAr, NameEn FROM Governorates";
        return _sqlHelper.ExecuteQueryAsync(sql, Map);
    }

    public Task<Governorate?> GetByIdAsync(int id)
    {
        string sql = "SELECT Id, NameAr, NameEn FROM Governorates WHERE Id = @Id";

        return _sqlHelper.ExecuteSingleAsync(sql, Map, p => p.Add("@Id", SqlDbType.Int).Value = id);
    }

    public async Task<Governorate> AddAsync(Governorate governorate)
    {
        string sql = @"INSERT INTO Governorates (NameAr, NameEn) 
                       VALUES (@NameAr, @NameEn);
                       SELECT SCOPE_IDENTITY();";

        var newId = await _sqlHelper.ExecuteScalarAsync(sql, p =>
        {
            p.Add("@NameAr", SqlDbType.NVarChar).Value = governorate.NameAr;
            p.Add("@NameEn", SqlDbType.NVarChar).Value = governorate.NameEn;
        });

        governorate.Id = Convert.ToInt32(newId);
        return governorate;
    }

    public async Task<Governorate?> UpdateAsync(Governorate governorate)
    {
        string sql = @"UPDATE Governorates 
                       SET NameAr = @NameAr, NameEn = @NameEn 
                       WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p =>
        {
            p.Add("@Id", SqlDbType.Int).Value = governorate.Id;
            p.Add("@NameAr", SqlDbType.NVarChar).Value = governorate.NameAr;
            p.Add("@NameEn", SqlDbType.NVarChar).Value = governorate.NameEn;
        });

        return rows > 0 ? governorate : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        string sql = "DELETE FROM Governorates WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p => p.Add("@Id", SqlDbType.Int).Value = id);
        return rows > 0;
    }

    private static Governorate Map(SqlDataReader reader) =>
        new()
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            NameAr = reader.GetString(reader.GetOrdinal("NameAr")),
            NameEn = reader.GetString(reader.GetOrdinal("NameEn"))
        };
}