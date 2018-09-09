using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExtendedComboBox
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ExtendedComboBoxControl : UserControl
    {

        public string ComboBoxName { get; set; }

        public Dictionary<string,string> ItemSource { get; set; }
        public static DependencyProperty ItemSourceProperty = DependencyProperty.Register(
                                            "ItemSource",
                                            typeof(Dictionary<string, string>),
                                            typeof(ExtendedComboBoxControl),
                                            new PropertyMetadata(new Dictionary<string, string> { { "", "" } }));

        public KeyValuePair<string, string> SelectedValue
        {
            get { return (KeyValuePair<string, string>)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

       // public KeyValuePair<string, string> SelectedValue { get; set; }
       public static DependencyProperty SelectedValueProperty = DependencyProperty.Register(
                                    "SelectedValue",
                                    typeof(KeyValuePair<string, string>),
                                    typeof(ExtendedComboBoxControl),
                                    new PropertyMetadata(new KeyValuePair<string, string> ("", "")));

        public ExtendedComboBoxControl()
        {
            InitializeComponent();
        }
    }
}
