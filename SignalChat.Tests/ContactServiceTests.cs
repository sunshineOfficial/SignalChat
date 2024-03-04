using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Contact;
using SignalChat.Services;
using SignalChat.Services.Exceptions;

namespace SignalChat.Tests;

/// <summary>
/// Тесты <see cref="ContactService"/>.
/// </summary>
public class ContactServiceTests
{
    /// <summary>
    /// Проверяет, что при валидном запросе пользователь добавляется в контакты.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddUserToContacts_ValidRequest_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        [Frozen] Mock<IContactRepository> contactRepositoryMock,
        AddUserToContactsRequest request,
        ContactService contactService)
    {
        // Arrange
        request.UserId = request.FriendId + 1;
        userRepositoryMock.Setup(x => x.IsUserExistsById(request.FriendId)).ReturnsAsync(true);
        contactRepositoryMock.Setup(x => x.IsContactExists(request.UserId, request.FriendId)).ReturnsAsync(false);
        
        // Act
        await contactService.AddUserToContacts(request);
        
        // Assert
        contactRepositoryMock.Verify(x => x.CreateContact(It.IsAny<DbContact>()), Times.Once);
    }
    
    /// <summary>
    /// Проверяет, что при попытке добавить в контакты самого себя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddUserToContacts_UserIdEqualsFriendId_ThrowsException(
        AddUserToContactsRequest request,
        ContactService contactService)
    {
        // Arrange
        request.UserId = request.FriendId;
        
        // Act
        var act = () => contactService.AddUserToContacts(request);
        
        // Assert
        await Assert.ThrowsAsync<AddUserToContactsException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при попытке добавить в контакты несуществующего пользователя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddUserToContacts_FriendDoesNotExists_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        AddUserToContactsRequest request,
        ContactService contactService)
    {
        // Arrange
        request.UserId = request.FriendId + 1;
        userRepositoryMock.Setup(x => x.IsUserExistsById(request.FriendId)).ReturnsAsync(false);
        
        // Act
        var act = () => contactService.AddUserToContacts(request);
        
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при попытке добавить в контакты пользователя еще раз выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task AddUserToContacts_ContactAlreadyExists_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        [Frozen] Mock<IContactRepository> contactRepositoryMock,
        AddUserToContactsRequest request,
        ContactService contactService)
    {
        // Arrange
        request.UserId = request.FriendId + 1;
        userRepositoryMock.Setup(x => x.IsUserExistsById(request.FriendId)).ReturnsAsync(true);
        contactRepositoryMock.Setup(x => x.IsContactExists(request.UserId, request.FriendId)).ReturnsAsync(true);
        
        // Act
        var act = () => contactService.AddUserToContacts(request);
        
        // Assert
        await Assert.ThrowsAsync<ContactAlreadyExistsException>(act);
    }
}