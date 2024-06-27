using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Builder;






namespace StagecraftDAL
{
    public class Configuration
    {
        public static IConfiguration ReadConfigValue()
        {

            IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();
            return config;
        }



//public class Program
//{
//    public static void Main(string[] args)
//    {
//        var configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .AddJsonFile("myappconfig.json", optional: false, reloadOnChange: false)
//            .Build();

//        CreateHostBuilder(args, configuration).Build().Run();
//    }

//    public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseConfiguration(config);
//                webBuilder.UseStartup<Startup>();
         

//   });
//}
    }
}
