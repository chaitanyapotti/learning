using PersonRepository.Interface;
using System.Collections.Generic;
using System.ComponentModel;

namespace PeopleViewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IPersonRepository repository;

        public MainViewModel()
        {
            repository = SimpleContainer.Get<IPersonRepository>();
        }

        private IEnumerable<Person> _people;
        public IEnumerable<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                RaisePropertyChanged("People");
            }
        }

        public string RepositoryType => repository.GetType().ToString();

        public void FetchData()
        {
            People = repository.GetPeople();
        }

        public void ClearData()
        {
            People = new List<Person>();
        } 

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
