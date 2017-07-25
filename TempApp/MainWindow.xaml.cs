using System;
using System.Collections.Generic;
using System.Globalization;
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
            Calculate();
            //BtnButton.Content = UcLabel.Text + UcLabel2.Text;
        }

        public async void Calculate()
        {
            for (;;)
            {
                double sum = 0;

                void Function()
                {
                    for (int i = 0; i < 200000000; i++)
                    {
                        sum += Math.Sqrt(i);
                    }
                }

                await Task.Run((Action) Function);
                UcLabel.Text = "sum = " + sum;
                await Task.Run(() =>
                    {
                        for (int i = 0; i < 200000000; i++)
                        {
                            sum += Math.Sqrt(i);
                        }
                    }
                );
                UcLabel.Text = "sum = " + sum;
                await Task.Run(() =>
                    {
                        for (int i = 0; i < 200000000; i++)
                        {
                            sum += Math.Sqrt(i);
                        }
                    }
                );
                UcLabel.Text = "sum = " + sum;
                await Task.Run(() =>
                    {
                        for (int i = 0; i < 200000000; i++)
                        {
                            sum += Math.Sqrt(i);
                        }
                    }
                );
                UcLabel.Text = "sum = " + sum;
            }


        }

        private void BtnButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked");
            var values = Enum.GetValues(typeof(Party));
        }





        //public string DpProp
        //{
        //    get => (string)GetValue(DpPropProperty);
        //    set => SetValue(DpPropProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for dpProp.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DpPropProperty =
        //    DependencyProperty.Register("DpProp", typeof(string), typeof(Button), new PropertyMetadata(null, new PropertyChangedCallback(ChangeInput)));

        //public static void ChangeInput(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        //{
        //    MainWindow wind = new MainWindow();

        //    wind.BtnButton.Content = wind.UcLabel.Text + wind.UcLabel2.Text;

        //}
        

    }

    public enum Party
    {
        Affiliation,
        State, Region
    }
}
