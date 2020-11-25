using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Warehouse_Management_System
{
    public class Program
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Warehouse;Trusted_Connection=True;MultipleActiveResultSets=true";
        private const string _schemaName = "dbo";
        private const string _tableName = "LogEvents";

        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration().WriteTo
                .MSSqlServer(
                    connectionString: _connectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = _tableName,
                        SchemaName = _schemaName,
                        AutoCreateSqlTable = true
                    },
                    restrictedToMinimumLevel: LogEventLevel.Debug,
                    formatProvider: null,
                    columnOptions: null,
                    logEventFormatter: null)
                .CreateLogger();

            Log.Debug("Getting started");

            Log.Information("Hello {Name} from thread {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"),
                Thread.CurrentThread.ManagedThreadId);

            CreateHostBuilder(args).Build().Run();
            Log.CloseAndFlush();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
