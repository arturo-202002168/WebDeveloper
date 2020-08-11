using NETCore.MailKit;
using NETCore.MailKit.Core;
using NETCore.MailKit.Infrastructure.Internal;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new MailKitProvider(new MailKitOptions
            {
                Server = "127.0.0.1",
                Port = 25,
                SenderName = "Test",
                SenderEmail = "test@mail.com",
            });

            var emailService = new EmailService(provider);

            emailService.Send("arturo@mail.com", "prueba", "mensaje");
        }
    }
}
