using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Lesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ComboBox.DataContext = this;
            list.Add(new Person { Age = 16, Name = "John" });
            list.Add(new Person { Age = 19, Name = "Julie" });
            //ComboBox.ItemsSource = list;
            Panel.AddHandler(Button.ClickEvent, new RoutedEventHandler(btn_Click));

            CommandBinding binding = new CommandBinding(ApplicationCommands.Copy);
            CommandBindings.Add(binding);
            binding.Executed += (o, args) => Debug.WriteLine("Command Executed");
        }

        public void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            btn.Background = Brushes.AliceBlue;
        }

        public List<Person> list { get; set; } = new List<Person>();

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Mouse Down" + sender);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
