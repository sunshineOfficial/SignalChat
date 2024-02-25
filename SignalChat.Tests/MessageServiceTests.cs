using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.Message;
using SignalChat.Services;
using SignalChat.Services.Exceptions;

namespace SignalChat.Tests;

/// <summary>
/// Тесты <see cref="MessageService"/>.
/// </summary>
public class MessageServiceTests
{
    /// <summary>
    /// Проверяет, что при валидном запросе отправляется новое сообщение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task SendMessage_ValidRequest_Success(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        [Frozen] Mock<IChatParticipantRepository> chatParticipantRepositoryMock,
        [Frozen] Mock<IMessageRepository> messageRepositoryMock,
        int messageId,
        SendMessageRequest request,
        MessageService messageService)
    {
        // Arrange
        chatRepositoryMock.Setup(x => x.IsChatExists(request.ChatId)).ReturnsAsync(true);
        chatParticipantRepositoryMock.Setup(x => x.IsChatParticipantExists(request.UserId, request.ChatId)).ReturnsAsync(true);
        messageRepositoryMock.Setup(x => x.CreateMessage(It.IsAny<DbMessage>())).ReturnsAsync(messageId);
        
        // Act
        var message = await messageService.SendMessage(request);
        
        // Assert
        Assert.Equal(messageId, message.Id);
        Assert.Equal(request.Text, message.Text);
        Assert.Equal(request.ChatId, message.ChatId);
        Assert.Equal(request.UserId, message.UserId);
        messageRepositoryMock.Verify(x => x.CreateMessage(It.IsAny<DbMessage>()), Times.Once);
    }

    /// <summary>
    /// Проверяет, что при невалидном Id чата выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task SendMessage_InvalidChatId_ThrowsException(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        SendMessageRequest request,
        MessageService messageService)
    {
        // Arrange
        chatRepositoryMock.Setup(x => x.IsChatExists(request.ChatId)).ReturnsAsync(false);
        
        // Act
        var act = () => messageService.SendMessage(request);
        
        // Assert
        await Assert.ThrowsAsync<ChatNotFoundException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при невалидном участнике чата выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task SendMessage_InvalidChatParticipant_ThrowsException(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        [Frozen] Mock<IChatParticipantRepository> chatParticipantRepositoryMock,
        SendMessageRequest request,
        MessageService messageService)
    {
        // Arrange
        chatRepositoryMock.Setup(x => x.IsChatExists(request.ChatId)).ReturnsAsync(true);
        chatParticipantRepositoryMock.Setup(x => x.IsChatParticipantExists(request.UserId, request.ChatId)).ReturnsAsync(false);
        
        // Act
        var act = () => messageService.SendMessage(request);
        
        // Assert
        await Assert.ThrowsAsync<ChatParticipantNotFoundException>(act);
    }

    /// <summary>
    /// Проверяет, что при валидном запросе возвращаются сообщения.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetMessagesByChat_ValidRequest_Success(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        [Frozen] Mock<IChatParticipantRepository> chatParticipantRepositoryMock,
        [Frozen] Mock<IMessageRepository> messageRepositoryMock,
        int userId,
        int chatId,
        DateTime from,
        MessageService messageService)
    {
        // Arrange
        chatRepositoryMock.Setup(x => x.IsChatExists(chatId)).ReturnsAsync(true);
        chatParticipantRepositoryMock.Setup(x => x.IsChatParticipantExists(userId, chatId)).ReturnsAsync(true);
        
        // Act
        var messages = await messageService.GetMessagesByChat(userId, chatId, from);
        
        // Assert
        Assert.NotNull(messages);
        messageRepositoryMock.Verify(x => x.GetMessagesByChat(chatId, from), Times.Once);
    }

    /// <summary>
    /// Проверяет, что при невалидном Id чата выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetMessagesByChat_InvalidChatId_ThrowsException(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        int userId,
        int chatId,
        DateTime from,
        MessageService messageService)
    {
        // Arrange
        chatRepositoryMock.Setup(x => x.IsChatExists(chatId)).ReturnsAsync(false);
        
        // Act
        var act = () => messageService.GetMessagesByChat(userId, chatId, from);
        
        // Assert
        await Assert.ThrowsAsync<ChatNotFoundException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при невалидном участнике чата выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetMessagesByChat_InvalidChatParticipant_ThrowsException(
        [Frozen] Mock<IChatRepository> chatRepositoryMock,
        [Frozen] Mock<IChatParticipantRepository> chatParticipantRepositoryMock,
        int userId,
        int chatId,
        DateTime from,
        MessageService messageService)
    {
        // Arrange
        chatRepositoryMock.Setup(x => x.IsChatExists(chatId)).ReturnsAsync(true);
        chatParticipantRepositoryMock.Setup(x => x.IsChatParticipantExists(userId, chatId)).ReturnsAsync(false);
        
        // Act
        var act = () => messageService.GetMessagesByChat(userId, chatId, from);
        
        // Assert
        await Assert.ThrowsAsync<ChatParticipantNotFoundException>(act);
    }
}