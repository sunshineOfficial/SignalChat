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

    public async Task UpdateUser(User user)
    {
        if (!await userRepository.IsUserExistsById(user.Id))
        {
            throw new UserNotFoundException(user.Id);
        }

        if (!string.IsNullOrEmpty(user.Username) && await userRepository.IsUserExistsByUsername(user.Username))
        {
            throw new UsernameAlreadyTakenException(user.Username);
        }

        if (!string.IsNullOrEmpty(user.Email) && await userRepository.IsUserExistsByEmail(user.Email))
        {
            throw new EmailAlreadyTakenException(user.Email);
        }

        await userRepository.UpdateUser(user.MapToDb());
    }

    public async Task DeleteUser(int id)
    {
        if (!await userRepository.IsUserExistsById(id))
        {
            throw new UserNotFoundException(id);
        }

        await userRepository.DeleteUser(id);
    }
}