using URAL.Application.Services;

namespace URAL.Application.IServices;

public interface IMessageService
{
    public Task SendAsync(EmailMessage emailMessage);

    public Task SendConfirmEmail(string email, string callbackUrl);
}

public record EmailMessage(string Email, string Subject, string Body);
