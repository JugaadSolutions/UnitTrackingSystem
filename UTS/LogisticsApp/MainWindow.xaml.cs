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
using LogisticsApp.Views;
using System.Configuration;
using UTS;
namespace LogisticsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String Location { get; set; }
        DashBoardView DashBoardView;
        LoginView LoginView;
        string Stage = String.Empty;
        public MainWindow()
        {
            InitializeComponent();
            LoginView = new Views.LoginView();
            DashboardGrid.Children.Add(LoginView);
            LoginView.OperatorIDTextBox.Focus();
            LoginView.LoginEvent += LoginView_LoginEvent;

            Location = ConfigurationManager.AppSettings["Location"];

            using( UTSDbContext db = new UTSDbContext())
            {
                try
                {
                    var location = db.Locations.Single(l => l.Name == Location);
                    if( location == null)
                    {
                        MessageBox.Show("Location Not Found.\nPlease Contact Administrator", "Application Message"
                            , MessageBoxButton.OK, MessageBoxImage.Error);
                        Application.Current.Shutdown();
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Application Error\n" + e.Message
                        
                        , "Application Message"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }
            }


            Stage = ConfigurationManager.AppSettings["Stage"];

            if (Stage == "Logistics")
            {
                BannerTextBlock.Text += Environment.NewLine + Location +  " - LOGISTICS APP";

            }
            else if (Stage == "Production")
            {
                BannerTextBlock.Text += Environment.NewLine + Location + " - PRODUCTION APP";

            }

            

           
               
        }

        void LoginView_LoginEvent(object sender, Views.LoginParams e)
        {
            this.DashboardGrid.Children.Clear();

            DashBoardView = new DashBoardView(Location, e.OperatorID,Stage);
            DashBoardView.LogoutEvent += DashBoardView_LogoutEvent;

            this.DashboardGrid.Children.Add(DashBoardView);
            
        }

        void DashBoardView_LogoutEvent(object sender, EventArgs e)
        {
            this.DashboardGrid.Children.Clear();
            LoginView = new LoginView();
            LoginView.LoginEvent +=LoginView_LoginEvent;
            this.DashboardGrid.Children.Add(LoginView);
            LoginView.OperatorIDTextBox.Focus();
        }
    }
}
