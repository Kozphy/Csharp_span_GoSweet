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

        public void SendMail()
        {
            var message = new MimeMessage();
            // email 季送人
            message.From.Add(new MailboxAddress("GoSweet", "GoSweet@gmail.com"));
            // email 收件者與位置
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", _mailAddress));
            // email 主題
            message.Subject = "GoSweet 忘記密碼重置";

            // email css
            string cssContent = @"
            <head>
                <style>
                    .fw-bold {
                      font-size: 20px;
                      font-weight: bold;
                    }
                </style>
            </head>";
            string htmlBody =
                $@"<h2>尊敬的客戶</h2>
            <p>我們收到重設您的密碼的請求。如果您並未發出此請求，請忽略此郵件。</p>
            <p class=fw-bold>若要重設密碼，請點擊下方的連結：</p>
            <p>
                    <a href =http://localhost:5183/{_controllerName}/ResetPassword?EmailAddress={_mailAddress}>
                        點擊這裡重設密碼
                    </a> 
            </p>
            <p>如果您需要進一步協助，請聯繫我們的支援團隊 GoSweet@gmail.com。</p>";

            // email 內容
            var builder = new BodyBuilder
            {
                // TODO: change port number to application port
                HtmlBody = String.Concat(cssContent, htmlBody)
            };

            message.Body = builder.ToMessageBody();


            using var client = new SmtpClient();

            string smtpServer = "smtp.gmail.com";
            client.Connect(smtpServer, 465, true);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate("dbdf0147@gmail.com", "lojqyqxyyhewnjrf");

            client.Send(message);
            client.Disconnect(true);

        }
    }
}
