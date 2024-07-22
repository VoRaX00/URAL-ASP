using URAL.Application.Services;

namespace URAL.Application.IServices;

public interface IMessageService
{
    public Task SendAsync(EmailMessage emailMessage);
}

public record EmailMessage(string Email, string Subject, string Body);
