using System;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Threading.Tasks;

namespace MailSender.Model
{
    public class EmailSendService
    {
        public string Server { get; set; }
        public int Port { get; set; }

        public string SendTo { get; set; }
        public string SendFrom { get; set; }

        public string MessageSubject { get; set; }
        public string MessageBody { get; set; }

        public MailMessage message;

        public EmailSendService()
        {
        }

        public void SendExecute(string user, string pass)
        {
            try
            {
                using (var message = new MailMessage(SendFrom, SendTo, MessageSubject, MessageBody))
                using (var client = new SmtpClient(Server, Port) { EnableSsl = true, Credentials = new NetworkCredential(user, pass) })
                {
                    client.Send(message);
                    Task.Run(() => MessageBox.Show("Письмо отправлено!", "Успешно"));
                }
                
            }
            catch (Exception error)
            {
                Task.Run(() => MessageBox.Show("Невозможно отправить письмо " + error.ToString(),"Ошибка"));
            }
        }
    }
}
