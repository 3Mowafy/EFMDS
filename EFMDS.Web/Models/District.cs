namespace EFMDS.Web.Models;

public class District
{
    public int Id { get; set; }
    public int GovernorateId { get; set; }
    public string? NameAr { get; set; } = string.Empty;
    public string? NameEn { get; set; } = string.Empty;
}