using Demo.BusinessLogicBLL.Services;
using Demo.BusinessLogicBLL.Services.Interfaces;
using Demo.DataAccessDAL_Infrastructure_.Data.Contexts;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories;
using Demo.DataAccessDAL_Infrastructure_.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region DI Contaier
            builder.Services.AddControllersWithViews();
            //2] Lifetimes (Objects) => AddScoped, AddSingeltion, AddTranisent

            //builder.Services.AddScoped<AppDbContext>();

            //AddDbContext => Allow DI DbContext 
            builder.Services.AddDbContext<AppDbContext>(op=>
            {
                //op.UseSqlServer("ConnectionString");
                //op.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultconnectionString"]);
                //op.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultconnectionString"]);
                //op.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultconnectionString"]);
                op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultconnectionString"));


            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            #endregion
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

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
/*
 Department Module
    --Model
       ->Name, Code, Description [Properties Dept]
       ->Id, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn, IsDeleted [All Models] [Parent Class]
 */