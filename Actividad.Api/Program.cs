using Actividad.Api.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace Actividad.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo cultura = CultureInfo.CreateSpecificCulture("es-MX");
            CultureInfo.DefaultThreadCurrentUICulture = cultura;
            CultureInfo.DefaultThreadCurrentCulture = cultura;

            Program.CreateHostBuilder(args).Build().MigrarBaseDatos().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(b => b.UseStartup<Startup>().UseUrls("https://192.168.1.101:44300"));
    }
}
