using MailKit.Net.Smtp;
using MimeKit;
using URAL.Application.IServices;

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

        //SmtpClient client = new SmtpClient(options.SmtpClient, options.Port);
        
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //client.UseDefaultCredentials = false;
        //client.Credentials = new System.Net.NetworkCredential(options.From, options.Pass);
        //client.EnableSsl = true;

        //var mail = new MailMessage(options.From, emailMessage.Email);
        //mail.Subject = emailMessage.Subject;
        //mail.IsBodyHtml = true;
        //mail.Body = emailMessage.Body;

        //await client.SendMailAsync(mail);
    }
}

public class MessageServiceOptions(string from, string pass, string smtpClient, int port)
{
    public string From { get; init; } = from;
    public string Pass { get; init; } = pass;
    public string SmtpClient { get; init; } = smtpClient;
    public int Port { get; init; } = port;
}