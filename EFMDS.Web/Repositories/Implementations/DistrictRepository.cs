using EFMDS.Web.Models;
using EFMDS.Web.Helpers;
using EFMDS.Web.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EFMDS.Web.Repositories.Implementations;

public class DistrictRepository : IDistrictRepository
{
    private readonly SqlHelper _sqlHelper;
    public DistrictRepository(SqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
    }

    public Task<List<District>> GetAllAsync()
    {
        string sql = "SELECT Id, governorateId, NameAr, NameEn FROM Districts";
        return _sqlHelper.ExecuteQueryAsync(sql, Map);
    }

    public Task<List<District>> GetByGovernorateAsync(int governorateId)
    {
        string sql = "SELECT Id, GovernorateId, NameAr, NameEn FROM Districts WHERE GovernorateId = @GovernorateId";
        return _sqlHelper.ExecuteQueryAsync(sql, Map,
            p => p.Add("@GovernorateId", SqlDbType.Int).Value = governorateId);
    }
    public Task<District?> GetByIdAsync(int id)
    {
        string sql = "SELECT Id, governorateId, NameAr, NameEn FROM Districts WHERE Id = @Id";

        return _sqlHelper.ExecuteSingleAsync(sql, Map, p => p.Add("@Id", SqlDbType.Int).Value = id);
    }

    public async Task<District> AddAsync(District district)
    {
        string sql = @"INSERT INTO Districts (governorateId, NameAr, NameEn) 
                       VALUES (@governorateId, @NameAr, @NameEn);
                       SELECT SCOPE_IDENTITY();";

        var newId = await _sqlHelper.ExecuteScalarAsync(sql, p =>
        {
            p.Add("@governorateId", SqlDbType.Int).Value = district.GovernorateId;
            p.Add("@NameAr", SqlDbType.NVarChar).Value = district.NameAr;
            p.Add("@NameEn", SqlDbType.NVarChar).Value = district.NameEn;
        });

        district.Id = Convert.ToInt32(newId);
        return district;
    }

    public async Task<District?> UpdateAsync(District district)
    {
        string sql = @"UPDATE Districts 
                       SET governorateId = @governorateId, NameAr = @NameAr, NameEn = @NameEn 
                       WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p =>
        {
            p.Add("@Id", SqlDbType.Int).Value = district.Id;
            p.Add("@governorateId", SqlDbType.Int).Value = district.GovernorateId;
            p.Add("@NameAr", SqlDbType.NVarChar).Value = district.NameAr;
            p.Add("@NameEn", SqlDbType.NVarChar).Value = district.NameEn;
        });

        return rows > 0 ? district : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        string sql = "DELETE FROM Districts WHERE Id = @Id";

        var rows = await _sqlHelper.ExecuteNonQueryAsync(sql, p => p.Add("@Id", SqlDbType.Int).Value = id);
        return rows > 0;
    }

    private static District Map(SqlDataReader reader) =>
        new()
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            GovernorateId = reader.GetInt32(reader.GetOrdinal("GovernorateId")),
            NameAr = reader.GetString(reader.GetOrdinal("NameAr")),
            NameEn = reader.GetString(reader.GetOrdinal("NameEn")),
        };
}