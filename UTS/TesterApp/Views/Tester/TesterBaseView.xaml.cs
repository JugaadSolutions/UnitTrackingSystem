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
using System.Windows.Threading;
using TesterApp;
using TesterApp.Views.Bays;

namespace TesterApp.Views.Tester
{
    /// <summary>
    /// Interaction logic for TesterBaseView.xaml
    /// </summary>
    public partial class TesterBaseView : UserControl
    {
        TesterApp.Tester Tester;

        StatusUpdateView sv;

        BayBaseView bbv;
     
        public TesterBaseView(String name)
        {
            InitializeComponent();

            using (BSDSContext db = new BSDSContext())
            {
                Tester = db.Testers.Include("Bays").SingleOrDefault(t => t.Name == name);
                
                
                TesterTag.Content+= Tester.Name;
                LocationTag.Content = Tester.Sector.Location.Name;
                SectorTag.Content = Tester.Sector.Name;
            }

            createTesterView();

        }


        void createTesterView()
        {
            using (BSDSContext db = new BSDSContext())
            {
                Tester = db.Testers.Include("Bays").SingleOrDefault(t => t.TesterID == Tester.TesterID);
            }
            switch (Tester.Status)
            {
                case 0:
                    sv = new StatusUpdateView(true, "Tester Breakdown Info");
                    sv.StatusDataView.StatusDataUpdateButton.Click += StatusDataUpdateButton_Click;
                    sv.StatusDataView.StatusCancelButton.Click += StatusCancelButton_Click;
                    StatusUpdateViewGrid.Children.Clear();
                    StatusUpdateViewGrid.Children.Add(sv);

                    MainGrid.RowDefinitions.Clear();
                    MainGrid.Children.Clear();
                    int i = 0;
                    foreach (Bay b in Tester.Bays)
                    {
                        RowDefinition rw = new RowDefinition();
                        bbv = new BayBaseView(b);
                        Grid.SetRow(bbv, i++);

                        MainGrid.RowDefinitions.Add(rw);
                        MainGrid.Children.Add(bbv);
                    }
                    break;

                case 1:
                    sv = new StatusUpdateView(false, "Tester Ready Info");
                    sv.StatusDataView.StatusDataUpdateButton.Click += StatusDataUpdateButton_Click;
                    StatusUpdateViewGrid.Children.Clear();
                    StatusUpdateViewGrid.Children.Add(sv);

                    MainGrid.Children.Clear();


                    Image FaultImage = new Image();
                    
                    BitmapImage fault = new BitmapImage(new Uri(@"/Images/Fault.png",UriKind.RelativeOrAbsolute));


                    FaultImage.Source = fault;

                    MainGrid.Children.Add(FaultImage);

                    break;
            }
        }

        void StatusCancelButton_Click(object sender, RoutedEventArgs e)
        {
            sv.StatusDataPopup.IsOpen = false;
            sv.StatusDataView.ClearView();
           
        }

        void StatusDataUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            sv.StatusDataPopup.IsOpen = false;
            if (sv.Status == true)
            {
                foreach (UIElement u in MainGrid.Children)
                {
                    ((BayBaseView)u).AddTesterBreakDownTransaction();
                }
            }

            using (BSDSContext db = new BSDSContext())
            {
                Tester = db.Testers.Include("TesterBreakdowns").SingleOrDefault(t => t.TesterID == Tester.TesterID);

                StatusInfo sInfo = new StatusInfo();
                sInfo.EngineerID = sv.StatusDataView.EngineerIDTextBox.Text;
                sInfo.Remarks = sv.StatusDataView.RemarksTextBox.Text;

                sInfo.Status = 



                Tester.Status = (Tester.Status == 0) ? 1 : 0;

                db.SaveChanges();
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                             new Action(() =>
                             {
                                 createTesterView();
                             }));



            }
        }

     

        


    }
}
