using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lesson4
{
    class EllipseRectangle : FrameworkElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect r = new Rect(0, 0, ActualWidth, ActualHeight);
            drawingContext.DrawRectangle(Brushes.Red, null, r);

            Point centerPoint = new Point(ActualWidth / 2, ActualHeight / 2);
            drawingContext.DrawEllipse(Brushes.Blue, new Pen(Brushes.Black, 4), centerPoint, ActualWidth / 2 - 4, ActualHeight / 2 - 4);
        }
    }
}
