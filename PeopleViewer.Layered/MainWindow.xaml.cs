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

namespace PeopleViewer.Layered
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            this.DataContext = _viewModel;
        }

        private void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.FetchData();
            ShowRepositoryType();
            //throw new NotImplementedException();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearData();
            //throw new NotImplementedException();
        }
        private void ShowRepositoryType()
        {
            MessageBox.Show($"Repository Type:\n{_viewModel.RepositoryType}");
        }
    }
}
