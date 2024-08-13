using Microsoft.AspNetCore.SignalR;
using URAL.Application.IServices;
using URAL.Application.RequestModels.Chat;
using URAL.Application.RequestModels.User;
using URAL.Application.Services;

namespace URAL.Hubs;

public class ChatHub(IChatService service) : Hub
{
    public async Task JoinChat(ChatToAdd newChat)
    {
        await service.AddAsync(newChat);
    }
} 