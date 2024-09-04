using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Chat;
using URAL.Application.RequestModels.Connection;
using URAL.Application.RequestModels.Message;

namespace URAL.Hubs;

public class ChatHub : Hub<IChatClient>
{
    private readonly IMessageService _service;
    public ChatHub(IMessageService service)
    {
        _service = service;
    }
    public async Task JoinChat(UserConnection connection)
    {
        var groupName = connection.ChatId.ToString();
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        
        var messages = await _service.GetByChatIdAsync(connection.ChatId, 1);
        await Clients.Caller.ReceiveMessages(connection.UserName, messages);
    }

    public async Task SendMessage(SentMessage message)
    {
        var groupName = message.Message.ChatId.ToString();
        await _service.AddAsync(message.Message, message.Message.UserId);
        await Clients.Groups(groupName).ReceiveMessage(message.UserName, message.Message);
    }

    public async Task EditMessage(MessageToUpdate message)
    {
        await _service.UpdateAsync(message);
    }

    public async Task DeleteMessage(MessageToDelete message)
    {
        await _service.DeleteAsync(message);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }
} 