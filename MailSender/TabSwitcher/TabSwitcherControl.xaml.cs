using System.Windows;
using System.Windows.Controls;

namespace TabSwitcher
{
    public partial class TabSwitcherControl : UserControl
    {
        public event RoutedEventHandler Back;
        public event RoutedEventHandler Forward;

        public TabSwitcherControl() => InitializeComponent();

        private void BackwardButton_Click(object sender, RoutedEventArgs e) => Back?.Invoke(this, new RoutedEventArgs());
        private void ForwardButton_Click(object sender, RoutedEventArgs e) => Forward?.Invoke(this, new RoutedEventArgs());
    }
}
