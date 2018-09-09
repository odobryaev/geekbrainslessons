using System.Windows;
using MailSender.ViewModel;

namespace MailSender
{
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            WpfMailSenderVM vm = new WpfMailSenderVM();
            DataContext = vm;
        }
        private void TabSwitcherControl_OnBack(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == 0) return;
            MainTabControl.SelectedIndex--;
        }

        private void TabSwitcherControl_OnForward(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1) return;
            MainTabControl.SelectedIndex++;
        }
    }
}
