using URAL.Domain.Entities;

public interface IChatClient
{
    public Task ReceiveMessage(User user, Message message);
}