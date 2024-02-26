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

    public async Task UpdateUser(UpdateUserRequest request)
    {
        if (!await userRepository.IsUserExistsById(request.Id))
        {
            throw new UserNotFoundException(request.Id);
        }

        if (!string.IsNullOrEmpty(request.Username) && await userRepository.IsUserExistsByUsername(request.Username))
        {
            throw new UsernameAlreadyTakenException(request.Username);
        }

        if (!string.IsNullOrEmpty(request.Email) && await userRepository.IsUserExistsByEmail(request.Email))
        {
            throw new EmailAlreadyTakenException(request.Email);
        }

        await userRepository.UpdateUser(request.MapToDb());
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