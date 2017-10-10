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

namespace Lesson4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Control.PivotEngine.EnableOnDemandCalculations = true;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ScaleTransform transform = new ScaleTransform(2, 2);
            EllipseRectangle ellipseRectangle = e.Source as EllipseRectangle;
            ellipseRectangle.RenderTransform = transform;
            e.Handled = true;
        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScaleTransform transform = new ScaleTransform(0.5, 0.5);
            EllipseRectangle ellipseRectangle = e.Source as EllipseRectangle;
            ellipseRectangle.RenderTransform = transform;
        }
    }
}
