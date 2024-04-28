namespace project_name
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //servicos
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
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
