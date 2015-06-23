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
using TesterApp;
using TesterApp.Models;
using TesterApp.Views;
namespace TesterApp.Views.Bays
{
    /// <summary>
    /// Interaction logic for BayBaseView.xaml
    /// </summary>
    public partial class BayBaseView : UserControl
    {
        int BayID;
        Bay Bay;
        BayReadyView brv ;
        BayActiveView bav;
        

        TestUnit tu;
        UnitTestCycle cycle;
        ProductModel p;
        TestTransaction transaction;
        StatusUpdateView sv ;

        public BayBaseView(Bay bay)
        {
            InitializeComponent();

            BayID = bay.BayID;
            Bay = bay;

            BayTag.Content = Bay.Name;

            createBayView();
        }

        void createBayView()
        {

            try
            {



                switch (Bay.Status)
                {
                    case 0:

                        brv = new BayReadyView();
                        brv.StartButton.Click += StartButton_Click;
                        MainGrid.Children.Clear();
                        MainGrid.Children.Add(brv);


                        sv = new StatusUpdateView(true, "Bay Breakdown Info");
                          sv.StatusDataView.StatusDataUpdateButton.Click += StatusDataUpdateButton_Click;
                          sv.StatusDataView.StatusCancelButton.Click += StatusCancelButton_Click;
                        StatusUpdateViewGrid.Children.Add(sv);
                        break;

                    case 2:
                        using (var db = new BSDSContext())
                        {
                            Bay = db.Bays.Include("TestTransactions").SingleOrDefault(b => b.BayID == BayID);

                            transaction = Bay.TestTransactions.Last(b => b.Status == 0);
                            cycle = transaction.UnitTestCycle;
                            tu = cycle.TestUnit;

                            bav = new BayActiveView(transaction.UnitTestCycle.StartTimestamp,
                                transaction.UnitTestCycle.TestUnit.ProductModel.CycleTime.Value);

                            bav.EngineerIDTextBox.Text = transaction.EngineerID;
                            bav.SerialNoTextBox.Text = tu.SerialNo;
                            bav.ModelTextBox.Text = tu.ProductModel.Name;

                            bav.PassButton.Click += PassButton_Click;
                            bav.FailButton.Click += FailButton_Click;

                            MainGrid.Children.Clear();
                            MainGrid.Children.Add(bav);
                            

                            sv = new StatusUpdateView(true, "Bay Breakdown Info");
                            sv.StatusDataView.StatusDataUpdateButton.Click += StatusDataUpdateButton_Click;
                            sv.StatusDataView.StatusCancelButton.Click += StatusCancelButton_Click;
                            StatusUpdateViewGrid.Children.Add(sv);
                        }
                        break;

                    case 1:

                        MainGrid.Children.Clear();
                        Image FaultImage = new Image();

                        BitmapImage fault = new BitmapImage(new Uri(@"/Images/Fault.png", UriKind.RelativeOrAbsolute));


                        FaultImage.Source = fault;

                        MainGrid.Children.Add(FaultImage);

                        sv = new StatusUpdateView(false, "Bay Ready Info");
                        sv.StatusDataView.StatusDataUpdateButton.Click += StatusDataUpdateButton_Click;
                        sv.StatusDataView.StatusCancelButton.Click += StatusCancelButton_Click;
                        StatusUpdateViewGrid.Children.Add(sv);
                        break;
                }
            }
            catch (Exception exp)
            {
            }
            
        }

   
        void createNewTestUnit()
        {
            DateTime ts = DateTime.Now;

            tu = new TestUnit(p.ProductModelID, 0, brv.SerialNoTextBox.Text);

            cycle = new UnitTestCycle(ts, 0);

            transaction = new TestTransaction(Bay.BayID, brv.EngineerIDTextBox.Text, ts, "", 0);
            cycle.TestTransactions.Add(transaction);

            tu.UnitTestCycles.Add(cycle);
        }

        void updateTestCycle(int cycleStatus, int transactionStatus)
        {
            using (BSDSContext db = new BSDSContext())
            {
                DateTime ts = DateTime.Now;
                Bay = db.Bays.SingleOrDefault(b => b.BayID == Bay.BayID);
                tu = db.TestUnits.Include("UnitTestCycles").Include("UnitTestCycles.TestTransactions")
                    .SingleOrDefault(t => t.TestUnitID == tu.TestUnitID);
                cycle = tu.UnitTestCycles.First(c => c.UnitTestCycleID == cycle.UnitTestCycleID);


                transaction = new TestTransaction(Bay.BayID,
                    bav.EngineerIDTextBox.Text, ts, sv.StatusDataView.RemarksTextBox.Text, transactionStatus, cycle.UnitTestCycleID);
                cycle.TestTransactions.Add(transaction);
                cycle.Status = cycleStatus;
                cycle.EndTimestamp = ts;
                Bay.Status = 0; //Ready
                db.SaveChanges();
            }
        }
    
        void FailButton_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                          new Action(() =>
                          {
                              bav.StatusDataView.ClearView();
                              bav.StatusDataView.HeaderLabel.Content = "Failure Info";
                              bav.StatusDataView.StatusDataUpdateButton.Click += FailureDataUpdateButton;
                              bav.StatusDataView.StatusCancelButton.Click += BAV_StatusCancelButton_Click;
                              double primScreenHeight = System.Windows.SystemParameters.FullPrimaryScreenHeight;
                              double primScreenWidth = System.Windows.SystemParameters.FullPrimaryScreenWidth;
                              bav.StatusDataPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Center;
                              bav.StatusDataPopup.PlacementTarget = Window.GetWindow(this);
                              bav.StatusDataPopup.IsOpen = true;
                          }));

           
            
        }

        void PassButton_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                         new Action(() =>
                         {
                             bav.StatusDataView.HeaderLabel.Content = "Pass Info";
                             bav.StatusDataView.StatusDataUpdateButton.Click += PassDataUpdateButton;
                             bav.StatusDataView.StatusCancelButton.Click += BAV_StatusCancelButton_Click;
                             double primScreenHeight = System.Windows.SystemParameters.FullPrimaryScreenHeight;
                             double primScreenWidth = System.Windows.SystemParameters.FullPrimaryScreenWidth;
                             bav.StatusDataPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Center;
                             bav.StatusDataPopup.PlacementTarget = Window.GetWindow(this);
                             bav.StatusDataPopup.IsOpen = true;
                         }));
        }

        void BAV_StatusCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if( bav != null )
                bav.StatusDataPopup.IsOpen = false;

            
        }

        private void FailureDataUpdateButton(object sender, RoutedEventArgs e)
        {
            bav.StatusDataPopup.IsOpen = false;
            updateTestCycle(4, 2); //Failure
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                           new Action(() =>
                           {
                               createBayView();
                           }));


        }

        private void PassDataUpdateButton(object sender, RoutedEventArgs e)
        {
            bav.StatusDataPopup.IsOpen = false;
            int cycleStatus = 1;
            if (bav.ProgressPercentage > 100)
                cycleStatus = 2;
            else if (bav.ProgressPercentage < 100)
                cycleStatus = 3;
            updateTestCycle(cycleStatus, 1);
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                           new Action(() =>
                           {
                               createBayView();
                           }));
        }


        #region START_EVENT
        void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (brv.EngineerIDTextBox.Text == String.Empty || brv.ModelTextBox.Text == String.Empty
                            || brv.SerialNoTextBox.Text == String.Empty)
            {
                MessageBox.Show("Fields Cannot be Empty. Please enter relevant data", "Tester App-Info", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            using (BSDSContext db = new BSDSContext())
            {
                p = db.ProductModels.SingleOrDefault(m => m.Name == brv.ModelTextBox.Text);
                 tu = db.TestUnits
                     .Include("UnitTestCycles")
                     .Include("UnitTestCycles.TestTransactions")
                     .SingleOrDefault((t => (t.SerialNo == brv.SerialNoTextBox.Text) && p.ProductModelID == t.ProductModelID));
                Bay = db.Bays.SingleOrDefault(b => b.BayID == Bay.BayID);
                try
                {

                    if (tu == null)
                    {

                        Bay = db.Bays.SingleOrDefault(b => b.BayID == BayID);

                        createNewTestUnit();

                        db.TestUnits.Add(tu);

                        Bay.Status = 2;//Bay is active
                        db.SaveChanges();
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        new Action(() =>
                        {
                            createBayView();
                        }));
                    }

                    else
                    {
                        brv.RestartResumeView.HeaderLabel.Content = "Test Cycle Info";
                        brv.RestartResumeView.RestartButton.Click += RestartButton_Click;
                        brv.RestartResumeView.ResumeButton.Click += ResumeButton_Click;
                        brv.RestartResumeView.CancelButton.Click += CancelButton_Click;
                        brv.RestartResumePopup.IsOpen = true;
                    }

                  
                }
                catch(Exception exp)
                {

                    MessageBox.Show("Error In Application.Please Retry\n IF error remains Contact Application Manager", "Tester App - Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    

                }

            }
                   
        }
        #endregion

    
        void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            brv.RestartResumePopup.IsOpen = false;
            brv.RestartResumeView.RestartButton.Click -= RestartButton_Click;
            brv.RestartResumeView.ResumeButton.Click -= ResumeButton_Click;
            brv.RestartResumeView.CancelButton.Click -= CancelButton_Click;
        }

        void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            
            using (BSDSContext db = new BSDSContext())
            {
                Bay = db.Bays.SingleOrDefault(b => b.BayID == Bay.BayID);
                transaction = new TestTransaction(Bay.BayID, brv.EngineerIDTextBox.Text, DateTime.Now, brv.RestartResumeView.RemarksTextBox.Text, 0);
                UnitTestCycle cycle = (db.UnitTestCycles.Include("TestTransactions").Where(c => c.TestUnitID == tu.TestUnitID)
                                        .OrderByDescending(c => c.StartTimestamp)
                                        .ToList())[0];
                cycle.TestTransactions.Add(transaction);
                Bay.Status = 2;
                db.SaveChanges();
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                          new Action(() =>
                          {
                              createBayView();
                          }));
                    
                    
               
            }
                    
            
            
        }

        void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            using (BSDSContext db = new BSDSContext())
            {
                Bay = db.Bays.SingleOrDefault(b => b.BayID == Bay.BayID);
                tu = db.TestUnits.Include("UnitTestCycles")
                    .SingleOrDefault(t => t.TestUnitID == tu.TestUnitID);
                DateTime ts = DateTime.Now;
                cycle = new UnitTestCycle(tu.TestUnitID,ts, 0);
                transaction = new TestTransaction(Bay.BayID,brv.EngineerIDTextBox.Text,
                    ts,brv.RestartResumeView.RemarksTextBox.Text,0);

                cycle.TestTransactions.Add(transaction);
                tu.UnitTestCycles.Add(cycle);
                Bay.Status = 2;
                db.SaveChanges();
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                          new Action(() =>
                          {
                              createBayView();
                          }));
                    
                    
                db.SaveChanges();
            }
        }


        void StatusCancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (sv != null)
            {
                sv.StatusDataPopup.IsOpen = false;
                sv.StatusDataView.ClearView();
            }

        }

        void StatusDataUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            sv.StatusDataPopup.IsOpen = false;
            

            using (BSDSContext db = new BSDSContext())
            {
                if( sv.Status == true )
                {
                    if (Bay.Status == 2 )
                    {
                        int testcycleId = cycle.UnitTestCycleID;
                        Bay = db.Bays.SingleOrDefault(b => b.BayID == BayID);
                        cycle = db.UnitTestCycles.Include("TestTransactions").Where(c => c.UnitTestCycleID == testcycleId).Single();
                        transaction = new TestTransaction(BayID, sv.StatusDataView.EngineerIDTextBox.Text,
                            DateTime.Now, sv.StatusDataView.RemarksTextBox.Text, 3, testcycleId);
                        cycle.TestTransactions.Add(transaction);

                        
                    }
                    Bay.Status = 1;


                }
                else
                    Bay.Status = 0;

                db.SaveChanges();


            }

            this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                         new Action(() =>
                         {
                             createBayView();
                         }));



        }

        public void AddTesterBreakDownTransaction()
        {
            if (Bay.Status == 2)
            {

                using (BSDSContext db = new BSDSContext())
                {
                    int testcycleId = cycle.UnitTestCycleID;
                    Bay = db.Bays.SingleOrDefault(b => b.BayID == BayID);
                    cycle = db.UnitTestCycles.Include("TestTransactions").Where(c => c.UnitTestCycleID == testcycleId).Single();
                    transaction = new TestTransaction(BayID, sv.StatusDataView.EngineerIDTextBox.Text,
                        DateTime.Now, sv.StatusDataView.RemarksTextBox.Text, 4, testcycleId);
                    cycle.TestTransactions.Add(transaction);
                    Bay.Status = 0;
                    db.SaveChanges();
                }
            }
        }


    }
}
