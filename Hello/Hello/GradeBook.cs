using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "empty";
            grades = new List<double>();
        }
        protected List<double> grades;

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
            //throw new NotImplementedException();
        }

        public override void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private string _name;

        public override string Name
        {
            get

            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if(_name !=value)
                    {
                        NameDelegate?.Invoke(_name, value);

                        var args = new NameChangedEventArgs
                        {
                            ExistingName = _name,
                            NewName = value
                        };
                        NameDelegate2?.Invoke(this, args);
                    }
                    _name = value;
                }
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            var stats = new GradeStatistics
            {
                AverageGrade = grades.Average(),
                HighestGrade = grades.Max(),
                LowestGrade = grades.Min()
            };

            return stats;
        }

        public event NameChangedDelegate NameDelegate;

        public event NameChangedDelegate2 NameDelegate2;
    }
}
