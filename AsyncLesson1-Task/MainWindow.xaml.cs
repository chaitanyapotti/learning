using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncLesson1_Task
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicator.Visibility = Visibility.Visible;
            LoginButton.IsEnabled = false;
            var task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Login Successful";
            });

            //task.ContinueWith((t) =>
            //{
            //    if (t.IsFaulted)
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            LoginButton.Content = "Login failed";
            //            LoginButton.IsEnabled = true;
            //        });
            //    }
            //    else
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            LoginButton.Content = t.Result;
            //            LoginButton.IsEnabled = true;
            //        });
            //    }
            //});

            //Here continuation is not executed on the UI thread. Hence, we need to use Dispatcher Invoke
            task.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
            {
                LoginButton.Content = task.Result;
                LoginButton.IsEnabled = true;
                BusyIndicator.Visibility = Visibility.Hidden;
            });
        }
    }
}
