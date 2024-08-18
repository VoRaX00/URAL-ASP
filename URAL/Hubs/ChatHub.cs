using Microsoft.AspNetCore.SignalR;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Connection;
using URAL.Application.RequestModels.Message;

namespace URAL.Hubs;

public class ChatHub(IMessageService service, string groupName) : Hub<IChatClient>
{
    public async Task JoinChat(UserConnection connection)
    {
        groupName = connection.ChatId.ToString();
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        var messages = await service.GetByChatIdAsync(connection.ChatId, 1);
        await Clients.User(connection.UserId).ReceiveMessages(connection.UserName, messages);
    }

    public async Task SendMessage(SentMessage message)
    {
        await service.AddAsync(message.Message, message.Message.UserId);
        await Clients.Groups(groupName).ReceiveMessage(message.UserName, message.Message);
    }

    public async Task EditMessage(MessageToUpdate message)
    {
        await service.UpdateAsync(message);
    }

    public async Task DeleteMessage(MessageToDelete message)
    {
        await service.DeleteAsync(message);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        await base.OnDisconnectedAsync(exception);
    }
} 