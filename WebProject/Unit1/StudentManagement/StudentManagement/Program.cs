using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StudentManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                    //����NLog��Ϊ��־�ṩ����֮һ
                    logging.AddNLog();

                    //ֻʹ��Nlog��Ϊ��־����
                    //ɾ������Ĭ�ϼ�¼��־�ṩ����
                    //logging.ClearProviders();
                    //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //���NLog��Ϊ��־�ṩ����
                    //logging.AddNLog();
                }).ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
