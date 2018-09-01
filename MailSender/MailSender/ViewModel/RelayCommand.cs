using System;
using System.Windows.Input;

namespace MailSender.ViewModel
{
    // Скопировал из интернета для реализации команд в соответствии с MVVM
    public class RelayCommand : ICommand
    {
        private Action<object> _action;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
               // var passwordBox = parameter as PasswordBox;
              //  var password = passwordBox.Password;
                _action(parameter);
            }
        }
        public event EventHandler CanExecuteChanged;
    }
}
