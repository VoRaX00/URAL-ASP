using URAL.Application.Base;
using URAL.Application.RequestModels.Message;

namespace URAL.Hubs;

public interface IChatClient
{
    Task ReceiveMessage(string userName, MessageToAdd message);
    Task ReceiveMessages(string userName, PaginatedList<MessageToGet> message);
}