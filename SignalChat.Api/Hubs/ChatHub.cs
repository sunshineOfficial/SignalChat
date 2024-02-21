using Microsoft.AspNetCore.SignalR;
using SignalChat.Models.Chat;
using SignalChat.Models.Message;
using SignalChat.Services.Interfaces;

namespace SignalChat.Api.Hubs;

/// <summary>
/// Хаб чатов.
/// </summary>
public class ChatHub(IConnectionTracker connectionTracker, IChatService chatService, IMessageService messageService, IChatParticipantService chatParticipantService) : BaseHub
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
        var connectionIds = connectionTracker.SelectConnectionIds(request.UserIds);
        addToGroupTasks.AddRange(connectionIds.Select(connectionId => Groups.AddToGroupAsync(connectionId, $"Chat{chat.Id}")));
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
    
    public override async Task OnConnectedAsync()
    {
        connectionTracker.TrackConnection(Context.ConnectionId, Id);

        // подключаемся к группам чатов, в которых мы есть
        var chatParticipants = await chatParticipantService.GetChatParticipantsByUserId(Id);
        var chatIds = chatParticipants.Select(x => x.ChatId);
        var addToGroupTasks = chatIds.Select(chatId => Groups.AddToGroupAsync(Context.ConnectionId, $"Chat{chatId}"));
        await Task.WhenAll(addToGroupTasks);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        connectionTracker.UntrackConnection(Context.ConnectionId);
        
        await base.OnDisconnectedAsync(exception);
    }
}