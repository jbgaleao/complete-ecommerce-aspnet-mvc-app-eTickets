using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace eTickets
{
    public class Program
    {
        public static void Main(System.String[ ] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(System.String[ ] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
