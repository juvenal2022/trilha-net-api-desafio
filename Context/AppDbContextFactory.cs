
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TrilhaApiDesafio.Context;

namespace trilha_net_api_desafio.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<OrganizadorContext>
    {
        public OrganizadorContext CreateDbContext(string[] args)
        {
            // Carrega o .env explicitamente
        Env.Load();

        var server = Environment.GetEnvironmentVariable("DB_SERVER");
        var port = Environment.GetEnvironmentVariable("DB_PORT");
        var database = Environment.GetEnvironmentVariable("DB_NAME");
        var user = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

        var connectionString =
            $"Server={server};Port={port};Database={database};User={user};Password={password};";

        var optionsBuilder = new DbContextOptionsBuilder<OrganizadorContext>();
        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );

        return new OrganizadorContext(optionsBuilder.Options);
        }
    }
}