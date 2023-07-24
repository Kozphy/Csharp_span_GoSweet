using GoSweet.Interfaces;
using MimeKit;

namespace GoSweet.Implement
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string sendMessage)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("GoSweet", "GoSweet.gmail.com"));

            message.To.Add(new MailboxAddress("Customer", email));

            message.Subject = subject;
            //string smtpAddress = ""
            //string mail = "dbdf0147@gmail.com";
            //string pw = 
            throw new NotImplementedException();
        }
    }
}
