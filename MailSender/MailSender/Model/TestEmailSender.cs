using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows;

namespace MailSender.Model
{
    public static class TestEmailSender
    {
        private static string _server = "smtp.gmail.com";
        private static int _port = 587;

        public static void SendTestEmail(string user, string pass)
        {
            const string from = "odobryaev@gmail.com";
            const string to = "odobryaev@gmail.com";
            try
            {
                using (var message = new MailMessage(from, to, "Test message", "Test message body"))
                using (var client = new SmtpClient(_server, _port) { EnableSsl = true, Credentials = new NetworkCredential(user, pass)})
                {
                    client.Send(message);
                }
            }
            catch (SmtpException error)
            {
                //Console.WriteLine(error.Message);
                MessageBox.Show(error.Message, "При отправке сообщения возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
               // var dlg = new MessageSendCompletedDlg(error.Message);
               // dlg.ShowDialog();
            }
        }
    }
}
