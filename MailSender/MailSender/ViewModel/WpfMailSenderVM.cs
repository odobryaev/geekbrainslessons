using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailSender.ViewModel;
using MailSender.Model;
using System.Windows.Controls;

namespace MailSender.ViewModel
{
    public class WpfMailSenderVM
    {
        public Dictionary<string,string> Sender
        {
            get
            {
                return Senders.SenderDictionary;
            }
        }

        public Dictionary<string,int> Server
        {
            get
            {
                return Senders.ServerDictionary;
            }
        }

        public IQueryable EmailList
        {
            get
            {
                return Database.Emails;
            }
        }

        public string Username { get; set; }

        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public RelayCommand TestButtonClick
        {
            get
            {
                return
                new RelayCommand(action =>
                {
                    var passwordBox = action as PasswordBox;
                    var password = passwordBox.Password;
                    TestEmailSender.SendTestEmail(Username, password);
                }
                );
            }
        }

        public RelayCommand SendButtonClick
        {
            get
            {
                return
                new RelayCommand(action =>
                {
                    var passwordBox = action as PasswordBox;
                    var password = passwordBox.Password;
                    EmailSendService email = new EmailSendService()
                    {
                        SendTo = this.SendTo,
                        SendFrom = this.Username,
                        MessageSubject = this.Subject,
                        MessageBody = this.Body
                    };
                    email.SendExecute(Username,password);
                }
                );
            }
        }
    }
}
