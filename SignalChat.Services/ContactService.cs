using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Contact;
using SignalChat.Services.Exceptions;
using SignalChat.Services.Interfaces;
using SignalChat.Services.Mappers;

namespace SignalChat.Services;

/// <summary>
/// Сервис контактов.
/// </summary>
public class ContactService(IContactRepository contactRepository, IUserRepository userRepository) : IContactService
{
    public async Task AddUserToContacts(AddUserToContactsRequest request)
    {
        if (request.FriendId == request.UserId)
        {
            throw new AddUserToContactsException();
        }
        
        if (!await userRepository.IsUserExistsById(request.FriendId))
        {
            throw new UserNotFoundException(request.FriendId);
        }

        if (await contactRepository.IsContactExists(request.UserId, request.FriendId))
        {
            throw new ContactAlreadyExistsException(request.UserId, request.FriendId);
        }

        await contactRepository.CreateContact(request.MapToDb());
    }
}