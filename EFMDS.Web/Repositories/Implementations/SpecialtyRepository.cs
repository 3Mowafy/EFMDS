using EFMDS.Web.Models;
using EFMDS.Web.Helpers;
using EFMDS.Web.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EFMDS.Web.Repositories.Implementations;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly SqlHelper _sqlHelper;
    public SpecialtyRepository(SqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
    }

    public Task<List<Specialty>> GetAllAsync()
    {
        string sql = "SELECT Id, NameAr, NameEn, IconUrl FROM Specialties";
        return _sqlHelper.ExecuteQueryAsync(sql, Map);
    }

    public Task<Specialty?> GetByIdAsync(int id)
    {
        string sql = "SELECT Id, NameAr, NameEn, IconUrl FROM Specialties WHERE Id = @Id";

        return _sqlHelper.ExecuteSingleAsync(sql, Map, p => p.Add("@Id", SqlDbType.Int).Value = id);
    }

    public async Task<Specialty> AddAsync(Specialty specialty)
    {
        string sql = @"INSERT INTO Specialties (NameAr, NameEn, IconUrl) 
                       VALUES (@NameAr, @NameEn, @IconUrl);
                       SELECT SCOPE_IDENTITY();";

        var newId = await _sqlHelper.ExecuteScalarAsync(sql, p =>
        {
            p.Add("@NameAr", SqlDbType.NVarChar).Value = specialty.NameAr;
            p.Add("@NameEn", SqlDbType.NVarChar).Value = specialty.NameEn;
            p.Add("@IconUrl", SqlDbType.NVarChar).Value = (object?)specialty.IconUrl ?? DBNull.Value;
        });

        specialty.Id = Convert.ToInt32(newId);
        return specialty;
    }

    public async Task<Specialty?> UpdateAsync(Specialty specialty)
    {
        string sql = @"UPDATE Specialties 
                       SET NameAr = @NameAr, NameEn = @NameEn, IconUrl = @IconUrl 
                       WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p =>
        {
            p.Add("@Id", SqlDbType.Int).Value = specialty.Id;
            p.Add("@NameAr", SqlDbType.NVarChar).Value = specialty.NameAr;
            p.Add("@NameEn", SqlDbType.NVarChar).Value = specialty.NameEn;
            p.Add("@IconUrl", SqlDbType.NVarChar).Value = (object?)specialty.IconUrl ?? DBNull.Value;
        });

        return rows > 0 ? specialty : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        string sql = "DELETE FROM Specialties WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p => p.Add("@Id", SqlDbType.Int).Value = id);
        return rows > 0;
    }

    private static Specialty Map(SqlDataReader reader) =>
        new()
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            NameAr = reader.GetString(reader.GetOrdinal("NameAr")),
            NameEn = reader.GetString(reader.GetOrdinal("NameEn")),
            IconUrl = reader.IsDBNull(reader.GetOrdinal("IconUrl")) ? null : reader.GetString(reader.GetOrdinal("IconUrl"))
        };
}