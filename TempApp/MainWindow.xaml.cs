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

namespace TempApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnButton.Content = UcLabel.Text + UcLabel2.Text;
        }



        public string DpProp
        {
            get => (string)GetValue(DpPropProperty);
            set => SetValue(DpPropProperty, value);
        }

        // Using a DependencyProperty as the backing store for dpProp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DpPropProperty =
            DependencyProperty.Register("DpProp", typeof(string), typeof(Button), new PropertyMetadata(null, new PropertyChangedCallback(ChangeInput)));

        public static void ChangeInput(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            MainWindow wind = new MainWindow();
            
            wind.BtnButton.Content = wind.UcLabel.Text + wind.UcLabel2.Text;

        }

    }
}
