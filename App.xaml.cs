using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using CalibrationToolWPF.notifications;
using CalibrationToolWPF.sessions;

namespace CalibrationToolWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            NotificationManager.getInstance().closeAllNotifications();
            SessionManager.getInstance().closeAllSessions();
            base.OnExit(e);
        }
    }

}
