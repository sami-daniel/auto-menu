namespace project_name
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //servicos
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext();
            //cria o WebApplication
            var app = builder.Build();
            //habilita os middlewares para lidar com certas requisições
            app.UseRouting();
            app.MapControllers();
            app.UseStaticFiles();

            //roda a aplicacao
            app.Run();
        }
    }
}
