using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PeopleViewer.Layered.Annotations;
using PersonRepository.Interface;

namespace PeopleViewer.Layered
{
    class MainViewModel : INotifyPropertyChanged
    {
        private IPersonRepository _repository;

        private IEnumerable<Person> people;
        public IEnumerable<Person> People
        {
            get => people;
            set
            {
                people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public string RepositoryType => _repository.GetType().ToString();

        public MainViewModel()
        {
            _repository = RepositoryFactory.GetRepository();
        }

        public void FetchData()
        {
            People = _repository.GetPeople();
        }

        public void ClearData()
        {
            People = new List<Person>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository()
        {
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            object repoInstance = Activator.CreateInstance(repoType);
            IPersonRepository repo = repoInstance as IPersonRepository;
            return repo;
        }
    }
}
