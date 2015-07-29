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
using LogisticsApp;

namespace LogisticsApp.Views
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    /// 


   
    public partial class DashBoardView : UserControl
    {
        
        private string Location;
        private string Operator;
        private string Stage;

        TransactionCollection TransactionCollection;

        public event EventHandler LogoutEvent;

        public DashBoardView()
        {
            InitializeComponent();
            TransactionCollection = new TransactionCollection();
        }

        public DashBoardView(string Location, string p,string stage)
        {
            // TODO: Complete member initialization
            this.Location = Location;
            this.Operator = p;
            this.Stage = stage;
            InitializeComponent();
            TransactionCollection = new TransactionCollection();
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
                    LogisticTransaction lt = new LogisticTransaction();

                    lt.Location= Location;
                    lt.OperatorID= Operator;
                    lt.Timestamp = DateTime.Now;
                    lt.Status = TransactionStatus.DISPATCHED;
                    unit.Status = (int)TransactionStatus.DISPATCHED;

                    unit.LogisticTransactions.Add(lt);
                    
                    db.TestUnits.Add(unit);
                    db.SaveChanges();

                }

                else
                {
                    if ((TransactionStatus)unit.Status == TransactionStatus.RELEASED)
                    {
                        MessageBox.Show("Unit Released for Testing", "UTS Message",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;

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
                    UnitStatusGrid.DataContext = TransactionCollection;
                }
            }
        }

        private void updateUnitStatusDisplay(TestUnit unit)
        {
            TransactionCollection.Clear();

            foreach( Transaction t in unit.LogisticTransactions)
            {
                TransactionCollection.Add(t);
            }

         


        }

        private void updateUnitStatus(TestUnit unit)
        {
             LogisticTransaction t = new LogisticTransaction();

              t.Location = Location;
             t.OperatorID = Operator;
             t.Timestamp = DateTime.Now;

            if ((TransactionStatus)unit.Status == TransactionStatus.REWORK)
            {

                unit.Status = (int)TransactionStatus.DISPATCHED;

                


              
                t.Status = TransactionStatus.DISPATCHED;
                unit.LogisticTransactions.Add(t);
                
                return;

            }

                if ((TransactionStatus)unit.Status == TransactionStatus.DISPATCHED)
                {

                    unit.Status = TransactionStatus.RECEIVED;

                   
                    t.Status = TransactionStatus.RECEIVED;
                    unit.LogisticTransactions.Add(t);
                    return;

                }

                if ((TransactionStatus)unit.Status == TransactionStatus.RECEIVED)
                {

                    unit.Status = TransactionStatus.RELEASED;

                  
                    t.Status = TransactionStatus.RELEASED;
                    unit.LogisticTransactions.Add(t);

                }
               
               

            
            
        }
    }
}
