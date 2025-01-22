using System;
using Microsoft.Extensions.Configuration;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace FBMAS.External.Data.Repositories;

public interface ILogsRepository
{
    Task AddLogAsync(string log);
}

public class LogsRepository : ILogsRepository
{
    private IDapper _dapper;
    private ILogger<LogsRepository> _logger;

    public LogsRepository(ILogger<LogsRepository> logger, IDapper dapper)
    {
        _logger = logger;
        _dapper = dapper;
    }

    public async Task AddLogAsync(string log)
    {
        _logger.LogDebug($"attempting to add log with cs {_dapper.Connection.ConnectionString}");

        await _dapper.Connection.OpenAsync();

        await _dapper.Connection.ExecuteAsync("insert into Logs (Timestamp, Log) VALUES (NOW(), @log)", new { log });

        await _dapper.Connection.CloseAsync();

        _logger.LogDebug("alledgedly done adding logs");
    }



}
