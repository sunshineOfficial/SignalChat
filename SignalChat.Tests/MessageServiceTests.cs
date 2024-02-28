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
        Assert.Null(message.EditedOn);
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

    /// <summary>
    /// Проверяет, что при валидном запросе сообщение редактируется.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task EditMessage_ValidRequest_Success(
        [Frozen] Mock<IMessageRepository> messageRepositoryMock,
        EditMessageRequest request,
        DbMessage dbMessage,
        MessageService messageService)
    {
        // Arrange
        dbMessage.UserId = request.UserId;
        messageRepositoryMock.Setup(x => x.GetMessageById(request.Id)).ReturnsAsync(dbMessage);
        
        // Act
        var editedMessage = await messageService.EditMessage(request);
        
        // Assert
        Assert.Equal(request.Id, editedMessage.Id);
        Assert.Equal(request.EditedText, editedMessage.Text);
        Assert.Equal(dbMessage.SentOn, editedMessage.SentOn);
        Assert.Equal(dbMessage.ChatId, editedMessage.ChatId);
        Assert.Equal(request.UserId, editedMessage.UserId);
        messageRepositoryMock.Verify(x => x.EditMessage(request.Id, request.EditedText, It.IsAny<DateTime>()), Times.Once);
    }

    /// <summary>
    /// Проверяет, что при невалидном Id сообщения выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task EditMessage_InvalidId_ThrowsException(
        [Frozen] Mock<IMessageRepository> messageRepositoryMock,
        EditMessageRequest request,
        MessageService messageService)
    {
        // Arrange
        messageRepositoryMock.Setup(x => x.GetMessageById(request.Id)).ReturnsAsync(() => null);
        
        // Act
        var act = () => messageService.EditMessage(request);
        
        // Assert
        await Assert.ThrowsAsync<MessageNotFoundException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при попытке отредактировать чужое сообщение выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task EditMessage_InvalidUserId_ThrowsException(
        [Frozen] Mock<IMessageRepository> messageRepositoryMock,
        EditMessageRequest request,
        DbMessage dbMessage,
        MessageService messageService)
    {
        // Arrange
        request.UserId = 1;
        dbMessage.UserId = 2;
        messageRepositoryMock.Setup(x => x.GetMessageById(request.Id)).ReturnsAsync(dbMessage);
        
        // Act
        var act = () => messageService.EditMessage(request);
        
        // Assert
        await Assert.ThrowsAsync<EditMessageException>(act);
    }
}