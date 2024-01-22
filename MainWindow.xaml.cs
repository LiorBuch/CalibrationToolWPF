using System.Text;
using System.Windows;
using CalibrationToolWPF.notifications;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.IO;

namespace CalibrationToolWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clickmeClick(object sender, RoutedEventArgs e)
        {
            testBTN.Content = "clock";
            NotificationManager.getInstance().showAlertPopup(this);
        }
    }
}