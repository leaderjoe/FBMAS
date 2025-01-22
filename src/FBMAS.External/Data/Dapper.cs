using System;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace FBMAS.External.Data;

public interface IDapper
{
    NpgsqlDataSource DataSource { get; }
    NpgsqlConnection Connection { get; }
}

public class Dapper : IDapper
{

    public Dapper(IConfiguration config)
    {
        if (string.IsNullOrWhiteSpace(config.GetConnectionString("FBMAS")))
        {
            throw new Exception("Could get not connection string for FBMAS database");
        }
        DataSource = NpgsqlDataSource.Create(config.GetConnectionString("FBMAS"));
        Connection = DataSource.CreateConnection();
    }

    public NpgsqlDataSource DataSource { get; }
    public NpgsqlConnection Connection { get; }
}
