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
using TesterApp;


namespace TesterApp.Views
{
    /// <summary>
    /// Interaction logic for StatusUpdateView.xaml
    /// </summary>
    public partial class StatusUpdateView : UserControl
    {

        public event EventHandler<StatusUpdateEventArgs> StatusUpdateEvent;

        public StatusUpdateEventArgs StatusUpdateEventArgs { get; set; }

        public Boolean Status { get; set; }
        public StatusUpdateView(Boolean Status,String Header)
        {
            InitializeComponent();
           
            StatusDataView.HeaderLabel.Content = Header;

            StatusUpdateEventArgs = new StatusUpdateEventArgs();
            this.Status = Status;

            if (Status)
            {
                FaultButtonImage.Visibility = System.Windows.Visibility.Visible;
            }
            else OKButtonImage.Visibility = System.Windows.Visibility.Visible;
        }

        private void StatusUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            double primScreenHeight = System.Windows.SystemParameters.FullPrimaryScreenHeight;
            double primScreenWidth = System.Windows.SystemParameters.FullPrimaryScreenWidth;
            StatusDataPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Center;
            StatusDataPopup.PlacementTarget = Window.GetWindow(this);
            StatusDataPopup.IsOpen = true;
          
        }


    }


    public class StatusUpdateEventArgs : EventArgs
    {
        public String EngineerID { get; set; }
        public String Remarks { get; set; }
        public DateTime Timestamp { get; set; }
        public Boolean Status { get; set; }
        public String Source { get; set; }
    }
}

