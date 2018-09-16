using System;
using System.Linq;
using System.Windows.Threading;
using System.Windows;

namespace MailSender.Model
{
    public class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer(); 
        EmailSendService emailSender; 
        IQueryable<Emails> emails;
        IQueryable<SchedulerItems> letters;
        DateTime lastLetterTime;
        string _user;
        string _pass;

        public void SendEmails(IQueryable<SchedulerItems> letters, EmailSendService emailSender, IQueryable<Emails> emails, string user, string pass )
        {
            this.emailSender = emailSender;
            this.emails = emails;
            this.letters = letters;
            _user = user;
            _pass = pass;
            lastLetterTime = letters.Max(x => x.MessageDateTime);
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var letter in letters)
            {
                DateTime mdt = letter.MessageDateTime;
                DateTime dtn = DateTime.Now;
                DateTime ldt = lastLetterTime;
                if (mdt.AddSeconds(-mdt.Second).AddMilliseconds(-mdt.Millisecond).ToString() == dtn.AddSeconds(-dtn.Second).AddMilliseconds(-dtn.Millisecond).ToString())
                {
                    emailSender.MessageSubject = letter.Message;
                    emailSender.MessageBody = letter.Message;
                    foreach (var email in emails)
                    {
                        emailSender.SendTo = email.Value;
                        emailSender.SendExecute(_user, Encrypter.Crypter.Decrypt(_pass));
                    }
                    if (mdt.AddSeconds(-mdt.Second).AddMilliseconds(-mdt.Millisecond).ToString() == ldt.AddSeconds(-ldt.Second).AddMilliseconds(-ldt.Millisecond).ToString())
                    {
                        timer.Stop();
                        MessageBox.Show("Все письма отправлены.");
                    }
                    else Console.WriteLine("Not last!");
                }
            }
        }
    }
}
