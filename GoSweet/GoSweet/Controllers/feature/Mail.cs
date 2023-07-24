using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Cryptography;

namespace GoSweet.Controllers.feature
{
    public class Mail
    {
        private readonly string? _mailAddress = null;
        private readonly string? _controllerName = null;

        public Mail(string address, string controllerName)
        {
            _mailAddress = address;
            _controllerName = controllerName;
        }

        public string SendMail()
        {
            var message = new MimeMessage();
            // email 季送人
            message.From.Add(new MailboxAddress("GoSweet", "GoSweet@gmail.com"));
            // email 收件者與位置
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", _mailAddress));
            // email 主題
            message.Subject = "check for reset password'?";

            // email 內容
            var builder = new BodyBuilder
            {
                // TODO: change port number to application port
                HtmlBody = $@"<h1>點擊下方連結重置密碼: </h1> 
                <a href=http://localhost:5183/{_controllerName}/ResetPassword?EmailAddress={_mailAddress}>
                    click here to reset password 
                </a>"
            };
            message.Body = builder.ToMessageBody();


            using var client = new SmtpClient();

            try
            {
                string smtpServer = "smtp.gmail.com";
                client.Connect(smtpServer, 465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("dbdf0147@gmail.com", "lojqyqxyyhewnjrf");

                client.Send(message);
                client.Disconnect(true);
                return $"Send Email To {_mailAddress} Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
