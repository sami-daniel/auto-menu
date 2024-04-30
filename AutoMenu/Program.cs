using Entities;
using Services.Abstracao;
using Services.Implementacoes;

namespace AutoMenu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //servicos
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AutomenuDbContext>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            //cria o WebApplication
            var app = builder.Build();
            //habilita os middlewares para lidar com certas requisi��es
            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(name: "default",
                                   pattern: "{controller=Home}/{action=Index}"
                );

            //roda a aplicacao
            app.Run();
        }
    }
}
