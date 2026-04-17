namespace EFMDS.Web.Models;

public class Specialty
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string? IconUrl { get; set; }
}