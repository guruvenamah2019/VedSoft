using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Xml;
using System.Reflection;

namespace VedSoft.API
{
    public class Program
    {
        public static readonly log4net.ILog _log =log4net.LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            _log.Info("Application - Main is invoked latest");

            BuildWebHost(args).Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     // The ILoggingBuilder minimum level determines the
                     // the lowest possible level for logging. The log4net
                     // level then sets the level that we actually log at.
                     logging.AddLog4Net();
                     logging.SetMinimumLevel(LogLevel.Information);
                 })
                .Build();
    }
}
