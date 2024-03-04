using Microsoft.Extensions.DependencyInjection;
using SignalChat.Services.Interfaces;

namespace SignalChat.Services.Extensions;

/// <summary>
/// Класс с методами расширения для добавления функциональности сервисного слоя.
/// </summary>
public static class ServicesExtensions
{
    /// <summary>
    /// Добавляет сервисы.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/>.</param>
    /// <returns><see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IUserService, UserService>()
            .AddSingleton<IConnectionTracker, ConnectionTracker>()
            .AddScoped<IChatService, ChatService>()
            .AddScoped<IMessageService, MessageService>()
            .AddScoped<IChatParticipantService, ChatParticipantService>()
            .AddScoped<IContactService, ContactService>();
    }
}