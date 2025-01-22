using EduHome.Business.ServiceRegistrations;
using Essence.DataAccess.ServiceRegistrations;
using Essence.Presentation.Extensions;
using Microsoft.Data.SqlClient;
namespace Essence.Presentation;
public class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddControllersWithViews();
        builder.Services.AddBusinessServices();

        var app = builder.Build();

        await app.InitDatabaseAsync();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }

}
