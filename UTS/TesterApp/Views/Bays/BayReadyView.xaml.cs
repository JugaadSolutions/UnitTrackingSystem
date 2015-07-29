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

namespace TesterApp.Views.Bays
{
    /// <summary>
    /// Interaction logic for BayReadyView.xaml
    /// </summary>
    public partial class BayReadyView : UserControl
    {

        public event EventHandler<BayReadyEventArgs> BayReadyEvent;
        public BayReadyView()
        {
            InitializeComponent();

            EngineerIDTextBox.Clear();
            SerialNoTextBox.Clear();
            ModelTextBox.Clear();
        }

  

      
    }



    public class BayReadyEventArgs
    {
        public String EngineerID { get; set; }
        public String Model { get; set; }
        public String SerialNo { get; set; }

        public BayReadyEventArgs(String eID, String model, String sno)
        {
            EngineerID = eID;
            Model = model;
            SerialNo = sno;
        }
    }
}

