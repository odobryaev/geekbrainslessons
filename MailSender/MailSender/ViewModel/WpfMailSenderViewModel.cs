using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Model;
using MailSender.Services;

namespace MailSender.ViewModel
{
    public class WpfMailSenderViewModel : ViewModelBase
    {
        private readonly IDataAccessService _dataService;
        private Emails _currentEmail = new Emails();
        private ObservableCollection<Emails> _emails = new ObservableCollection<Emails>();

        public WpfMailSenderViewModel(IDataAccessService dataSerice)
        {
            _dataService = dataSerice;
            ReadAllMailsCommand = new RelayCommand(GetEmails);
            SaveMailCommand = new RelayCommand<Emails>(SaveEmail);
            DeleteMailCommand = new RelayCommand<Emails>(DeleteEmail);
            SendNowCommand = new RelayCommand(SendNow);
        }

        public ObservableCollection<Emails> Emails
        {
            get => _emails;
            set
            {
                if (!Set(ref _emails, value)) return;
            }
        }

        public Emails CurrentEmail
        {
            get => _currentEmail;
            set => Set(ref _currentEmail, value);
        }

        public string Subject { get; set; }
        public string Body { get; set; }

        public RelayCommand ReadAllMailsCommand { get; }
        public RelayCommand<Emails> SaveMailCommand { get; }
        public RelayCommand<Emails> DeleteMailCommand { get; }
        public RelayCommand SendNowCommand { get; }

        private void SaveEmail(Emails email)
        {
            email.Id = _dataService.CreateEmail(email);
            if (email.Id == 0) return;
            Emails.Add(email);
        }

        private void GetEmails()
        {
            Emails = _dataService.GetEmails();
        }

        private void DeleteEmail(Emails email)
        {
            _dataService.DeleteEmail(email);
           Emails.Remove(email);
        }

        private void SendNow()
        {
            EmailSendService email = new EmailSendService()
            {
                Server = SelectedServer.Key,
                Port = SelectedServer.Value,
                SendFrom = SelectedSender.Key,
                MessageSubject = this.Subject,
                MessageBody = this.Body
            };

            foreach (var e in _emails)
            {
                email.SendTo = e.Value;
                email.SendExecute(SelectedSender.Key, Encrypter.Crypter.Decrypt(SelectedSender.Value));
            }
        }

        public Dictionary<string, string> Sender
        {
            get => Senders.SenderDictionary;
        }
        public KeyValuePair<string, string> SelectedSender { get; set; }

        public Dictionary<string, int> Server
        {
            get => Senders.ServerDictionary;
        }
        public KeyValuePair<string, int> SelectedServer { get; set; }

    }
}
