using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalChat.DataAccess.Dapper;
using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Models.Settings;
using SignalChat.DataAccess.Repositories;
using SignalChat.DataAccess.Repositories.Interfaces;

namespace SignalChat.DataAccess.Migrations;

/// <summary>
/// Класс с методами расширения для добавления функциональности базы данных.
/// </summary>
public static class DatabaseExtensions
{
    /// <summary>
    /// Выполняет миграцию базы данных.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <param name="configuration"><see cref="IConfiguration"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection MigrateDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("SignalChatDatabase")["ConnectionString"];
        
        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransaction()
            .WithVariablesDisabled()
            .LogToConsole()
            .Build();

        if (upgrader.IsUpgradeRequired())
        {
            upgrader.PerformUpgrade();
        }

        return services;
    }

    /// <summary>
    /// Добавляет поддержку Dapper.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddDapper(this IServiceCollection services)
    {
        return services
            .AddSingleton<IDapperSettings, SignalChatDatabase>()
            .AddSingleton<IDapperContext<IDapperSettings>, DapperContext<IDapperSettings>>();
    }

    /// <summary>
    /// Добавляет репозитории.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IChatRepository, ChatRepository>()
            .AddScoped<IChatParticipantRepository, ChatParticipantRepository>();
    }
}