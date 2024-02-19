using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.User;
using SignalChat.Services.Exceptions;
using SignalChat.Services.Interfaces;
using SignalChat.Services.Mappers;

namespace SignalChat.Services;

/// <summary>
/// Сервис пользователей.
/// </summary>
public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> GetUser(int id)
    {
        var user = await userRepository.GetUser(id);
        if (user == null)
        {
            throw new UserNotFoundException(id);
        }

        return user.MapToDomain();
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await userRepository.GetUsers();

        return users.MapToDomain();
    }
}