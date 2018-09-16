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
        private SchedulerItems _selectedSchedulerItem = new SchedulerItems();
        private ObservableCollection<SchedulerItems> _schedulerItems = new ObservableCollection<SchedulerItems>();
        

        //private Dictionary<DateTime, string> _schedulerItems = new Dictionary<DateTime, string>() { { DateTime.Now, "SSS" } };
        //ObservableCollection<KeyValuePair<DateTime, string>> _schedulerItemsOC = new ObservableCollection<KeyValuePair<DateTime, string>>(SchedulerItems.);
        //private ObservableCollection<Dictionary<DateTime, string>> _schedulerItems = new ObservableCollection<Dictionary<DateTime, string>>();

        public WpfMailSenderViewModel(IDataAccessService dataSerice)
        {
            _dataService = dataSerice;
            ReadAllMailsCommand = new RelayCommand(GetEmails);
            AddEmailCommand = new RelayCommand(AddEmail);
            SaveMailCommand = new RelayCommand<Emails>(SaveEmail);
            DeleteMailCommand = new RelayCommand<Emails>(DeleteEmail);
            SendNowCommand = new RelayCommand(SendNow);
            AddLetterToSchedulerCommand = new RelayCommand(AddLetterToScheduler);
            DeleteLetterFromSchedulerCommand = new RelayCommand<SchedulerItems>(DeleteLetterFromScheduler);
            EditLetterCommand = new RelayCommand<SchedulerItems>(EditLetter);
        }

        public ObservableCollection<Emails> Emails
        {
            get => _emails;
            set
            {
                if (!Set(ref _emails, value)) return;
            }
        }

        public SchedulerItems SelectedSchedulerItem
        {
            get => _selectedSchedulerItem;
            set
            {
                if (!Set(ref _selectedSchedulerItem, value)) return;
            }
        }

        public Emails CurrentEmail
        {
            get => _currentEmail;
            set => Set(ref _currentEmail, value);
        }

        public ObservableCollection<SchedulerItems> SchedulerItems
        {
            get => _schedulerItems;
            set => Set(ref _schedulerItems, value);
        }


        public string Subject { get; set; }
        public string Body { get; set; }

        public RelayCommand ReadAllMailsCommand { get; }
        public RelayCommand AddEmailCommand { get; }
        public RelayCommand<Emails> SaveMailCommand { get; }
        public RelayCommand<Emails> DeleteMailCommand { get; }
        public RelayCommand SendNowCommand { get; }
        public RelayCommand AddLetterToSchedulerCommand { get; }
        public RelayCommand<SchedulerItems> DeleteLetterFromSchedulerCommand { get; }
        public RelayCommand<SchedulerItems> EditLetterCommand { get; }

        private void AddEmail()
        {     
            Emails.Add(new Emails { });
        }

        private void SaveEmail(Emails email)
        {
            
            email.Id = _dataService.CreateEmail(email);
            if (email.Id == 0) return;
            GetEmails();
            //Emails.Add(email);       
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

        public void AddLetterToScheduler()
        {
            SchedulerItems.Add(new SchedulerItems() { MessageDateTime = DateTime.Now, Message = "Test Schedule" });
        }

        public void DeleteLetterFromScheduler(SchedulerItems _current)
        {
            SchedulerItems.Remove(_current);
        }

        public void EditLetter(SchedulerItems _current)
        {
            SelectedSchedulerItem = _current;
            Console.WriteLine(SelectedSchedulerItem.MessageDateTime);
            //foreach (var e in SchedulerItems)
            //{
            //    Console.WriteLine(e.MessageDateTime + e.Header + e.Message);
            //}
            //Console.WriteLine("Here!");
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
