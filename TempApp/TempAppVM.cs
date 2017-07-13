using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPlot.Plotly;
using Microsoft.FSharp.Core;

namespace TempApp
{
    class TempAppVM
    {
        public TempAppVM()
        {
            var layout = new Microsoft.FSharp.Core.FSharpOption<XPlot.Plotly.Graph.Layout>(new Graph.Layout());
            Plot.Plot<Graph.Trace>(Listx, layout);
           
        }

        public PlotlyChart Plot { get; set; }

        public IEnumerable<Graph.Trace> Listx = new IEnumerable<Graph.Trace> {1, 2, 3, 6, 9};
    }
}
