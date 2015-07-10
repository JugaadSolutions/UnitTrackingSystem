using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace LogisticsApp.Views
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    /// 


    class UnitStatus
    {
        
        public String Status { get; set; }
        public String Location { get; set; }
        public String Date_Time { get; set; }
        public String Operator { get; set; }
    }

    class UnitStatusCollection : ObservableCollection<UnitStatus>
    {

    }
    public partial class DashBoardView : UserControl
    {
        public enum TransactionStatus
        {
            DISPATCHED, RECEIVED, RELEASED, TEST_STARTED, TEST_COMPLETE_ONTIME,
            TEST_COMPLETE_DELAY, TEST_COMPLETE_EARLY, TEST_FAILURE, TEST_PAUSED, REWORK, BAYBREAKDOWN, TESTERBREAKDOWN, FINISHED
        };
        private string Location;
        private string Operator;
        private string Stage;
        UnitStatusCollection UnitStatusCollection;

        public event EventHandler LogoutEvent;

        public DashBoardView()
        {
            InitializeComponent();
            UnitStatusCollection = new UnitStatusCollection();
        }

        public DashBoardView(string Location, string p,string stage)
        {
            // TODO: Complete member initialization
            this.Location = Location;
            this.Operator = p;
            this.Stage = stage;
            InitializeComponent();
            UnitStatusCollection = new UnitStatusCollection();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                var unit = db.TestUnits.SingleOrDefault(u => u.SerialNo == SerialNoTextBox.Text);
                if (unit == null)
                {
                    unit = new TestUnit();
                    unit.SerialNo = SerialNoTextBox.Text;
                    unit.DispatchParams_Location = Location;
                    unit.DispatchParams_OperatorID = Operator;
                    unit.Status = (int)TransactionStatus.DISPATCHED;
                    unit.DispatchParams_Timestamp = DateTime.Now;
                    db.TestUnits.Add(unit);
                    db.SaveChanges();

                }

                else
                {
                    if ((TransactionStatus)unit.Status == TransactionStatus.RELEASED)
                    {
                        MessageBox.Show("Unit Released for Testing", "UTS Message", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        updateUnitStatus(unit);

                        db.SaveChanges();

                       
                    }
                    
                }
            }

            SearchButton_Click(this, new RoutedEventArgs());
            MessageBox.Show("Status Updated", "UTS Message", MessageBoxButton.OK, MessageBoxImage.Information);
            UserControl_Loaded(this, new RoutedEventArgs());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.LogoutEvent != null)
            {
                LogoutEvent(this, new EventArgs());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.SerialNoTextBox.Focus();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            using (EntityModel db = new EntityModel())
            {
                var unit = db.TestUnits.SingleOrDefault(u => u.SerialNo == SerialNoTextBox.Text);
                if (unit == null)
                {
                    MessageBox.Show("Unit not Found", "Application Message", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    updateUnitStatusDisplay(unit);
                    UnitStatusGrid.DataContext = null;
                    UnitStatusGrid.DataContext = UnitStatusCollection;
                }
            }
        }

        private void updateUnitStatusDisplay(TestUnit unit)
        {
            UnitStatusCollection.Clear();

            if ((TransactionStatus)unit.Status == TransactionStatus.DISPATCHED)
            {

                UnitStatus s = new UnitStatus();

                s.Location = unit.DispatchParams_Location;
                s.Date_Time = unit.DispatchParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.DispatchParams_OperatorID;
                s.Status = "DISPATCHED";
                UnitStatusCollection.Add(s);
                return;
            }

            if ((TransactionStatus)unit.Status == TransactionStatus.RECEIVED)
            {

                UnitStatus s = new UnitStatus();
                s.Location = unit.DispatchParams_Location;
                s.Date_Time = unit.DispatchParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.DispatchParams_OperatorID;
                s.Status = "DISPATCHED";
                UnitStatusCollection.Add(s);

                s = new UnitStatus();
                s.Location = unit.ReceiveParams_Location;
                s.Date_Time = unit.ReceiveParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.ReceiveParams_OperatorID;
                s.Status = "RECEIVED";
                UnitStatusCollection.Add(s);
                return;
            }

            if ((TransactionStatus)unit.Status == TransactionStatus.RELEASED)
            {

                UnitStatus s = new UnitStatus();
                s.Location = unit.DispatchParams_Location;
                s.Date_Time = unit.DispatchParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.DispatchParams_OperatorID;
                s.Status = "DISPATCHED";
                UnitStatusCollection.Add(s);

                s = new UnitStatus();
                s.Location = unit.ReceiveParams_Location;
                s.Date_Time = unit.ReceiveParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.ReceiveParams_OperatorID;
                s.Status = "RECEIVED";
                UnitStatusCollection.Add(s);


                s = new UnitStatus();
                s.Location = unit.ReleaseParams_Location;
                s.Date_Time = unit.ReleaseParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.ReleaseParams_OperatorID;
                s.Status = "RELEASED";
                UnitStatusCollection.Add(s);
                return;
            }

            if(((TransactionStatus)unit.Status == TransactionStatus.TEST_COMPLETE_DELAY 
                ||(TransactionStatus)unit.Status == TransactionStatus.TEST_COMPLETE_EARLY
                ||(TransactionStatus)unit.Status == TransactionStatus.TEST_COMPLETE_ONTIME)
                && Stage == "Finishing")
            {
                UnitStatus s = new UnitStatus();
                s = new UnitStatus();
                s.Location = unit.ReleaseParams_Location;
                s.Date_Time = unit.ReleaseParams_Timestamp.Value.ToString("dd-MM-yyyy HH:mm:ss");
                s.Operator = unit.ReleaseParams_OperatorID;
                s.Status = "FINISHED";
                UnitStatusCollection.Add(s);
                return;
            }


        }

        private void updateUnitStatus(TestUnit unit)
        {
            
               

                if ((TransactionStatus)unit.Status == TransactionStatus.DISPATCHED)
                {

                    unit.Status = (int)TransactionStatus.RECEIVED;
                    unit.ReceiveParams_Location = Location;
                    unit.ReceiveParams_OperatorID = Operator;
                    unit.ReceiveParams_Timestamp = DateTime.Now;
                    return;

                }

                if ((TransactionStatus)unit.Status == TransactionStatus.RECEIVED)
                {

                    unit.Status = (int)TransactionStatus.RELEASED;
                    unit.ReleaseParams_Location = Location;
                    unit.ReleaseParams_OperatorID = Operator;
                    unit.ReleaseParams_Timestamp = DateTime.Now;

                }

               

            
            
        }
    }
}
