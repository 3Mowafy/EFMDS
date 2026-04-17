using EFMDS.Web.Repositories.Interfaces;
using EFMDS.Web.Repositories.Implementations;
using EFMDS.Web.Services.Interfaces;
using EFMDS.Web.Services.Implementations;
using EFMDS.Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SqlHelper>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/Error/NotFoundPage");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();