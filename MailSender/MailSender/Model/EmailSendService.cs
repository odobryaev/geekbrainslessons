using System;
using System.Net.Mail;
using System.Net;
using System.Windows;

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
                    MessageBox.Show("Письмо отправлено!","Успешно");
                    //var dlg = new MessageSendResultDlg();
                    //var vm = new MessageSendResultDlgViewModel();
                    //dlg.DataContext = vm;
                    //vm.ErrorText = "";
                    //vm.ResultText = "Message sent!";
                    //vm.ResultTextColor = "Green";
                    //vm.CloseHandler += (sender, args) => dlg.Close();
                    //dlg.ShowDialog();
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Невозможно отправить письмо " + error.ToString(),"Ошибка");
                //var dlg = new MessageSendResultDlg();
                //var vm = new MessageSendResultDlgViewModel(); 
                //dlg.DataContext = vm;
                //vm.ErrorText = error.Message;
                //vm.ResultText = "Error!";
                //vm.ResultTextColor = "Red";
                //vm.CloseHandler += (sender, args) => dlg.Close();
                //dlg.ShowDialog();

            }
        }
    }
}
