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
    class EmailSendService
    {
        private static string _server = "smtp.gmail.com";
        private static int _port = 587;

        public static string SendTo { get; set; }
        public static string SendFrom { get; set; }

        public static string MessageSubject { get; set; }
        public static string MessageBody { get; set; }

        public MailMessage message;

        public EmailSendService()
        {

        }

        public static void SendExecute()
        {

        }

        public static void EmailSendService1(string user, string pass)
        {
            try
            {
                using (var message = new MailMessage(SendFrom, SendTo, MessageSubject, MessageBody))
                using (var client = new SmtpClient(_server, _port) { EnableSsl = true, Credentials = new NetworkCredential(user, pass) })
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
