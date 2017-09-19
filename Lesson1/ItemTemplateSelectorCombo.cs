using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lesson1
{
    class ItemTemplateSelectorCombo : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var control = container as FrameworkElement;
            var person = item as Person;
            return person.Age > 18 ? control.FindResource("Normal") as DataTemplate : control.FindResource("AbNormal") as DataTemplate;

        }
    }
}
