using SignalChat.DataAccess.Dapper.Interfaces;
using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Chat;
using SignalChat.Services;
using SignalChat.Services.Exceptions;

namespace SignalChat.Tests;

/// <summary>
/// Тесты <see cref="ChatService"/>.
/// </summary>
public class ChatServiceTests
{
    /// <summary>
    /// Проверяет, что при валидном запросе создается новый чат.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task CreateChat_ValidRequest_Success(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        [Frozen] Mock<IChatParticipantRepository> chatParticipantRepositoryMock,
        int chatId,
        CreateChatRequest request,
        ChatService chatService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(It.IsAny<int>())).ReturnsAsync(true);
        chatRepositoryMock.Setup(x => x.CreateChat(It.IsAny<DbChat>(), It.IsAny<ITransaction>())).ReturnsAsync(chatId);
        
        // Act
        var chat = await chatService.CreateChat(request);
        
        // Assert
        Assert.Equal(chatId, chat.Id);
        Assert.Equal(request.Name, chat.Name);
        Assert.Equal(request.CreatorId, chat.CreatorId);
        chatRepositoryMock.Verify(x => x.CreateChat(It.IsAny<DbChat>(), It.IsAny<ITransaction>()), Times.Once);
        chatParticipantRepositoryMock.Verify(x => x.CreateChatParticipants(It.IsAny<List<DbChatParticipant>>(), It.IsAny<ITransaction>()), Times.Once);
    }

    /// <summary>
    /// Проверяет, что при невалидном Id создателя чата выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task CreateChat_InvalidCreatorId_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        CreateChatRequest request,
        ChatService chatService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(request.CreatorId)).ReturnsAsync(false);
        
        // Act
        var act = () => chatService.CreateChat(request);
        
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при невалидном Id участника чата выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task CreateChat_InvalidUserId_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        CreateChatRequest request,
        ChatService chatService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(request.UserIds.First())).ReturnsAsync(false);
        
        // Act
        var act = () => chatService.CreateChat(request);
        
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }
}