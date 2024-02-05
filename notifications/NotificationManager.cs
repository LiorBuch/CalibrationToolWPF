using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace CalibrationToolWPF.notifications
{
    public sealed class NotificationManager
    {
        private static Lazy<NotificationManager> notificationManager = new Lazy<NotificationManager>(() => new NotificationManager());
        private AlertPopup alertPopup = new AlertPopup();
        private ErrorPopup errorPopup = new ErrorPopup();
        private Popup popup;
        private NotificationManager()
        {
            popup = new Popup();
            popup.Placement = PlacementMode.Center;
            popup.PopupAnimation = PopupAnimation.Fade;
            DependencyPropertyDescriptor descriptor = DependencyPropertyDescriptor.FromProperty(Popup.IsOpenProperty, typeof(Popup));
            descriptor.AddValueChanged(popup, new EventHandler(notificationChange));
        }
        public static NotificationManager getInstance()
        {
            return notificationManager.Value;
        }
        public void showAlertPopup(Window window)
        {
            window.Dispatcher.Invoke(() =>
            {
                popup.PlacementTarget = window;
                popup.Child = alertPopup;
                popup.Width = alertPopup.Width;
                popup.Height = alertPopup.Height;
                this.popup.IsOpen = true;
                this.popup.StaysOpen = false;
            });
        }
        public void showErrorPopup(Window window)
        {
            window.Dispatcher.Invoke(() =>
            {
                popup.PlacementTarget = window;
                popup.Child = errorPopup;
                popup.Width = errorPopup.Width;
                popup.Height = errorPopup.Height;
                this.popup.IsOpen = true;
                this.popup.StaysOpen = false;
            });
        }
        public void closeAllNotifications()
        {
            this.popup.IsOpen = false;
        }
        private void notificationChange(object? sender, EventArgs e)
        {
            Popup? pop = sender as Popup;
            if (pop != null)
            {
                Window? window = popup.PlacementTarget as Window;
                if (pop.IsOpen)
                {
                    if (window != null)
                    {
                        window.Effect = new BlurEffect { Radius = 3, RenderingBias = RenderingBias.Performance };
                    }
                }
                else
                {
                    if (window != null)
                    {
                        window.Effect = null;
                    }
                }
            }
        }
    }
}
