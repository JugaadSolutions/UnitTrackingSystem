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
using System.Configuration;
using TesterApp.Views;
using TesterApp.Views.Tester;

namespace TesterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int bayCount = 0;
        String testerTag = String.Empty;
        Tester tester;
        public MainWindow()
        {
            InitializeComponent();
            
            testerTag = ConfigurationManager.AppSettings["TESTER_ID"];



            using (EntityModel db = new EntityModel())
            {
                tester = db.Testers.SingleOrDefault(t => t.Name == testerTag);
                if (tester == null)
                {
                    MessageBox.Show("Tester Configuation Not Found!! Please contact Application Manager",
                          "Tester App - Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    db.Dispose();
                    Application.Current.Shutdown();
                    return;

                }
            }

            TesterViewGrid.Children.Add(new TesterBaseView(testerTag));
            
        }

      


    }
}
