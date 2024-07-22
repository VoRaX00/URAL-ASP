using System.Net.Mail;
using URAL.Application.Base;
using URAL.Application.IServices;

namespace URAL.Application.Services;

public class MessageService(MessageServiceOptions options) : IMessageService
{
    public Task SendAsync(EmailMessage emailMessage)
    {
        SmtpClient client = new SmtpClient(options.SmtpClient, options.Port);

        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(options.From, options.Pass);
        client.EnableSsl = true;

        var mail = new MailMessage(options.From, emailMessage.Email);
        mail.Subject = emailMessage.Subject;
        mail.Body = emailMessage.Body;
        mail.IsBodyHtml = true;

        return client.SendMailAsync(mail);
    }
}

public class MessageServiceOptions(string from, string pass, string smtpClient, int port)
{
    public readonly string From = from;
    public readonly string Pass = pass;
    public readonly string SmtpClient = smtpClient;
    public readonly int Port = port;
}