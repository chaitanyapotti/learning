using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public delegate void NameChangedDelegate(string existingName, string newName);

    public delegate void NameChangedDelegate2(object sender, NameChangedEventArgs args);

}
