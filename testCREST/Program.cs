using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using testCREST.Models;

namespace testCREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("con"))
            );
            builder.Services.AddScoped<StudentBusinesLogic, StudentBusinesLogic>();
            builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<DataContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                 name: "default1",
                 pattern: "All"
                 );
            //app.UseEndpoints(Endpoint =>
            //{

            //    Endpoint.MapControllerRoute(name: "default", pattern: "All", defaults: "{controller=Student}/{action=Index}/{id?}");
            //});
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default2",
                pattern: "All"
                ,defaults: "{controller=Student}/{action=Index}/{id?}"
                );
            app.MapControllerRoute(
               name: "default2",
               pattern: "{controller=Student}/{action=Index}/{id?}");
            

            app.Run();
        }
    }
}