using Microsoft.AspNetCore.SignalR;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Chat;
using URAL.Application.RequestModels.Message;

namespace URAL.Hubs;

public class ChatHub(IMessageService service) : Hub<IChatClient>
{
    public async Task JoinChat()
    {
        
    }

    public async Task SendMessage(MessageToAdd message)
    {
        
    }
} 