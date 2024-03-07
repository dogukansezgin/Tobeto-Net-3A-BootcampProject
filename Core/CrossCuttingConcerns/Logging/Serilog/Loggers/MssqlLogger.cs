using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MssqlLogger : LoggerServiceBase
{
    public MssqlLogger()
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();

        var logConfig = configuration.GetSection("SerilogConfigurations:MssqlConfiguration").Get<MssqlConfiguration>() ?? throw new Exception("");

        MSSqlServerSinkOptions sinkOptions = new()
        { TableName = logConfig.TableName, AutoCreateSqlTable = logConfig.AutoCreateSqlTable };

        ColumnOptions columnOptions = new();

        Logger serilogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(logConfig.ConnectionString, sinkOptions, columnOptions: columnOptions)
            .CreateLogger();

        Logger = serilogConfig;
    }
}
