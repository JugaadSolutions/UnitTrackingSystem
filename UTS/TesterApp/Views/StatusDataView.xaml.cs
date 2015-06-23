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

namespace TesterApp.Views
{
    /// <summary>
    /// Interaction logic for StatusDataView.xaml
    /// </summary>
    public partial class StatusDataView : UserControl
    {
        public String Source = String.Empty;

        public StatusDataView()
        {
            InitializeComponent();
            EngineerIDTextBox.Focus();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            EngineerIDTextBox.Focus();
        }

        internal void ClearView()
        {
            EngineerIDTextBox.Clear();
            RemarksTextBox.Clear();

        }
    }
}
