using Microsoft.AspNetCore.SignalR;
using URAL.Application.RequestModels.User;

namespace URAL.Application.Hubs;

public interface IChatClient
{
    public Task ReceiveMessage(string userName, string message);
}


public class ChatHub : Hub<IChatClient>
{
    public async Task JoinChat(UserConnection connection)
    {
        var chatRoom = connection.FirstUserId + connection.SecondUserId;
        await Groups.AddToGroupAsync(Context.ConnectionId, chatRoom);
        await Clients.Group(chatRoom).ReceiveMessage("Admin", $"{connection.FirstUserId} присоеденился к чату");
    }
}