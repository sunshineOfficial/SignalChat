using Microsoft.AspNetCore.SignalR;
using SignalChat.Models.Chat;
using SignalChat.Models.Message;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Hubs;

/// <summary>
/// Хаб чатов.
/// </summary>
public class ChatHub(IConnectionTracker connectionTracker, IChatService chatService, IMessageService messageService) : BaseHub
{
    /// <summary>
    /// Создает новый чат.
    /// </summary>
    /// <param name="request">Новый чат.</param>
    public async Task CreateChat(CreateChatRequest request)
    {
        request.CreatorId = Id;
        var chat = await chatService.CreateChat(request);

        // добавляем всех подключенных пользователей в группу чата
        var addToGroupTasks = new List<Task> { Groups.AddToGroupAsync(Context.ConnectionId, $"Chat{chat.Id}") };
        addToGroupTasks.AddRange(connectionTracker.SelectConnectionIds(request.UserIds)
            .Select(connectionId => Groups.AddToGroupAsync(connectionId, $"Chat{chat.Id}")));
        await Task.WhenAll(addToGroupTasks);

        await Clients.Caller.SendAsync("ChatCreated", chat);
        await Clients.Group($"Chat{chat.Id}").SendAsync("AddedToChat", chat);
    }

    /// <summary>
    /// Отправляет сообщение в чат.
    /// </summary>
    /// <param name="request"><see cref="SendMessageRequest"/>.</param>
    public async Task SendMessage(SendMessageRequest request)
    {
        request.UserId = Id;
        var message = await messageService.SendMessage(request);
        await Clients.Group($"Chat{message.ChatId}").SendAsync("ReceiveMessage", message);
    }
    
    public override Task OnConnectedAsync()
    {
        connectionTracker.TrackConnection(Context.ConnectionId, Id);
        // TODO: Добавлять в группы новые подключения
        
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        connectionTracker.UntrackConnection(Context.ConnectionId);
        
        return base.OnDisconnectedAsync(exception);
    }
}