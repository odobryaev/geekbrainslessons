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
    public class MainWindowVM
    {
        public string Username { get; set; }

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
    }
}
