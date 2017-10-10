using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding("CurrentCulture") { Source = Thread.CurrentThread };
            BindingOperations.SetBinding(Block, TextBlock.TextProperty, binding);
            // or Block.SetBinding(TextBlock.TextProperty, binding);

            //To update the prop changed value to UI(target) from source(code), one way is to implement INotifyPropertyChanged interface
            //Another is to write the following code
            //Another is to use typedescriptor mechanism
            Block.GetBindingExpression(TextBlock.TextProperty)?.UpdateTarget();

            //This is the typedescriptor mechanism to update binding to UI
            var ctd = new CTD();
            ctd.AddProperty("Name");
            ctd.AddProperty("Age");
            //DataContext = ctd;

            DataContext = people;

        }

        public Person src { get; set; } = new Person() { Name = "John", Age = 22 };

        public List<Person> people { get; set; } = new List<Person>() { new Person() { Name = "jon", Age = 32 }, new Person() { Name = "Danerys", Age = 31 } };
    }

    public class Person : IDataErrorInfo
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        break;
                    case "Age":
                        if (Age < 21)
                            return "Not allowed";
                        break;
                    default:
                        return "";
                }
                return "";
            }
        }

        public string Error { get; }
    }

    public class CTD : CustomTypeDescriptor
    {
        private static readonly ICollection<PropertyDescriptor> _propertyDescriptors = new List<PropertyDescriptor>();

        public void AddProperty(string name)
        {
            _propertyDescriptors.Add(new MyPropertyDescriptor(name, null));
        }

        public override PropertyDescriptorCollection GetProperties()
        {
            return new PropertyDescriptorCollection(_propertyDescriptors.ToArray());
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public override EventDescriptorCollection GetEvents()
        {
            return null;
        }

        public override EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return null;
        }
    }

    public class MyPropertyDescriptor : PropertyDescriptor
    {
        private readonly IDictionary<object, object> _values;

        public MyPropertyDescriptor(string name, Attribute[] attrs) : base(name, attrs)
        {
            _values = new Dictionary<object, object>();
        }

        public MyPropertyDescriptor(MemberDescriptor descr) : base(descr)
        {
        }

        public MyPropertyDescriptor(MemberDescriptor descr, Attribute[] attrs) : base(descr, attrs)
        {
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override object GetValue(object component)
        {
            _values.TryGetValue(component, out object value);
            return value;
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            var oldValue = GetValue(component);

            if (oldValue != value)
            {
                _values[component] = value;
                OnValueChanged(component, new PropertyChangedEventArgs(base.Name));
            }
        }

        public override bool ShouldSerializeValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void AddValueChanged(object component, EventHandler handler)
        {
            // set a breakpoint here to see WPF attaching a value changed handler
            base.AddValueChanged(component, handler);
        }

        public override Type ComponentType { get; }
        public override bool IsReadOnly => false;

        public override Type PropertyType => typeof(object);
    }
}
