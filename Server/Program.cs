using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CRM_Server_Side;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Run();
    }

    public static IWebHost CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>().Build();
}