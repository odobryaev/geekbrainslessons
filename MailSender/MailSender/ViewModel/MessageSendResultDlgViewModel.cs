using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    public class MessageSendResultDlgViewModel : ViewModelBase
    {
        public string ResultText { get; set; }
        public string ResultTextColor { get; set; }
        public string ErrorText { get; set; }
        public EventHandler CloseHandler { get; set; }

        public RelayCommand CloseWindowCommand { get; }

        private void CloseWindow()
        {
            CloseHandler.Invoke(this, EventArgs.Empty);
        }

        public MessageSendResultDlgViewModel()
        {

        }

        //public MessageSendResultDlgViewModel(string _resultText = "Message sent", 
        //                                    string _resultTextColor = "Green", 
        //                                    string _errorText = "")
        //{
        //    //dlg.DataContext = vm;
        //    //vm.ErrorText = "";
        //    //vm.ResultText = "Message sent!";
        //    //vm.ResultTextColor = "Green";
        //    //vm.CloseHandler += (sender, args) => dlg.Close();
        //    CloseWindowCommand = new RelayCommand(CloseWindow);
        //    ResultText = _resultText;
        //    ResultTextColor = _resultTextColor;
        //    ErrorText = _errorText;
        //   // CloseHandler += (sender, args) => _event;
        //}
    }
}
