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

namespace CalendarApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenLoginWindow_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginWindow)
                {
                    // If it's already open, bring it to the front and return
                    window.Activate();
                    return;
                }
            }
            // if didn't find the window, create a new one
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Owner = this;

            // display the window
            loginWindow.ShowDialog();
        }

        private void OpenReigsterWindow_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is RegisterWindow)
                {
                    // If it's already open, bring it to the front and return
                    window.Activate();
                    return;
                }
            }
            // if didn't find the window, create a new one
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Owner = this;

            // display the window
            registerWindow.ShowDialog();
        }

        private void OpenNewEventWindow_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is NewEventWindow)
                {
                    // If it's already open, bring it to the front and return
                    window.Activate();
                    return;
                }
            }
            // if didn't find the window, create a new one
            NewEventWindow newEventWindow = new NewEventWindow();
            newEventWindow.Owner = this;

            // display the window
            newEventWindow.ShowDialog();
        }
    }
}
