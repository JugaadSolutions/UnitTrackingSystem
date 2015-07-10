using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TesterApp.Views.Bays
{
    /// <summary>
    /// Interaction logic for BayActiveView.xaml
    /// </summary>
    public partial class BayActiveView : UserControl
    {
        Timer progressTimer;
        DateTime StartTimestamp;
        double CycleTime;
        public double ProgressPercentage { get; set; }
        public BayActiveView(DateTime StartTs,double cycletime)
        {
            InitializeComponent();
          

           
            StartTimestamp = StartTs;
            CycleTime = cycletime;

            

            double ProgressPercentage = calculatePercentage(DateTime.Now);
            TestCycleProgressBar.Value = 200 - ProgressPercentage;
            PercentageTextBlock.Text = Math.Round((ProgressPercentage), 2).ToString() + "%";


            progressTimer = new Timer(60000);
            progressTimer.AutoReset = false;
            progressTimer.Elapsed += progressTimer_Elapsed;

            progressTimer.Start();
            
        }

        private double calculatePercentage(DateTime ts)
        {
            return Math.Round(((ts - StartTimestamp).TotalMinutes / (2* CycleTime)) * 200, 2);
        }

        void progressTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            progressTimer.Stop();

            DateTime ts = DateTime.Now;

            ProgressPercentage = calculatePercentage(ts);
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                             new Action(() =>
                             {
                                 this.TestCycleProgressBar.Value = 200 - ProgressPercentage;
                                 this.PercentageTextBlock.Text = ProgressPercentage.ToString() + "%";
                                 this.DurationTextBox.Text = Math.Round((ts - StartTimestamp).TotalMinutes).ToString() + " mins";
                             }));

            progressTimer.Start();

        }
    }
}
