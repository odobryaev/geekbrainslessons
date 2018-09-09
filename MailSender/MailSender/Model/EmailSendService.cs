using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Windows;
using MailSender.View;
using MailSender.ViewModel;

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
                    var dlg = new MessageSendResultDlg();
                    var vm = new MessageSendResultDlgVM();
                    dlg.DataContext = vm;
                    vm.ErrorText = "";
                    vm.ResultText = "Message sent!";
                    vm.ResultTextColor = "Green";
                    vm.CloseHandler += (sender, args) => dlg.Close();
                    dlg.ShowDialog();
                }
                
            }
            catch (Exception error)
            {
                var dlg = new MessageSendResultDlg();
                var vm = new MessageSendResultDlgVM(); 
                dlg.DataContext = vm;
                vm.ErrorText = error.Message;
                vm.ResultText = "Error!";
                vm.ResultTextColor = "Red";
                vm.CloseHandler += (sender, args) => dlg.Close();
                dlg.ShowDialog();

            }
        }
    }
}
