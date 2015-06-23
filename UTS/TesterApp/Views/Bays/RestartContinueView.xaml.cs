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

namespace TesterApp.Views.Bays
{
    /// <summary>
    /// Interaction logic for RestartContinueView.xaml
    /// </summary>
    public partial class RestartContinueView : UserControl
    {
        public RestartContinueView()
        {
            InitializeComponent();
        }

        internal void ClearView()
        {
            RemarksTextBox.Clear();
        }
    }
}
