using Servicos.Abstracao;
using Servicos.Implementacoes;

namespace AutoMenu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //servicos
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEnderecoServico, EnderecoServico>();
            builder.Services.AddScoped<IRestauranteServico, RestauranteServico>();
            //cria o WebApplication
            var app = builder.Build();
            //habilita os middlewares para lidar com certas requisi��es
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
