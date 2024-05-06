using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using Services.Implementations;

namespace AutoMenu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //servicos
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AutoMenuDbContext>(options => options.UseMySql("server=localhost;database=automenu_db;uid=root;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql")));
            //String de conexão deve ser setada como segredo de usuario ou variavel de ambiente pelo powershell
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            builder.Services.AddSession();
            //cria o WebApplication
            var app = builder.Build();
            //habilita os middlewares para lidar com certas requisi��es
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseSession();
            app.MapControllerRoute(name: "default",
                                   pattern: "{controller=Home}/{action=Index}"
                );

            //roda a aplicacao
            app.Run();
        }
    }
}
