using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class MessageSendResultDlgVM
    {
        public string ResultText { get; set; }
        public string ResultTextColor { get; set; }
        public string ErrorText { get; set; }
        public EventHandler CloseHandler { get; set; }

        public ICommand OkButtonClick => new RelayCommand(action =>
        {
            if (CloseHandler != null)
            {
                CloseHandler.Invoke(this, EventArgs.Empty);
            }
        });



    }
}
