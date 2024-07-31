using MailKit.Net.Smtp;
using MimeKit;
using URAL.Application.IServices;
using URAL.Application.RequestModels.User;

namespace URAL.Application.Services;

public class MessageService(MessageServiceOptions options) : IMessageService
{
    public async Task SendAsync(EmailMessage emailMessage)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("Администрация сайта", options.From));
        message.To.Add(new MailboxAddress("", emailMessage.Email));
        message.Subject = emailMessage.Subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = emailMessage.Body
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(options.SmtpClient, options.Port, true);
            await client.AuthenticateAsync(options.From, options.Pass);
            await client.SendAsync(message);

            await client.DisconnectAsync(true);
        }
    }

    public async Task SendConfirmEmail(string email, string callbackUrl)
    {
        await SendAsync(
            new(
                email, 
                "Confirm your account", 
                $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>"
                )
            );
    }
}

public class MessageServiceOptions(string from, string pass, string smtpClient, int port)
{
    public string From { get; init; } = from;
    public string Pass { get; init; } = pass;
    public string SmtpClient { get; init; } = smtpClient;
    public int Port { get; init; } = port;
}