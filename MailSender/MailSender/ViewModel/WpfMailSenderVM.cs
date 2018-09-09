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
        public  KeyValuePair<string, string> SelectedSender { get; set; }

        public Dictionary<string,int> Server
        {
            get
            {
                return Senders.ServerDictionary;
            }
        }
        public KeyValuePair<string, int> SelectedServer { get; set; }

        public IQueryable<Emails> EmailList
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

        public RelayCommand SendNowButtonClick
        {
            get
            {
                return
                new RelayCommand(action =>
                {
                    EmailSendService email = new EmailSendService()
                    {
                        Server = SelectedServer.Key,
                        Port = SelectedServer.Value,
                        SendFrom = SelectedSender.Key,
                        MessageSubject = this.Subject,
                        MessageBody = this.Body  
                    };

                    foreach (var e in EmailList)
                    {
                        email.SendTo = e.Value;
                        email.SendExecute(SelectedSender.Key, Encrypter.Crypter.Decrypt(SelectedSender.Value));
                    }
                }
                );
            }
        }
    }
}
