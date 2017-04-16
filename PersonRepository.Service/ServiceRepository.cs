using PersonRepository.Interface;
using PersonRepository.Service.MyService;
using System.Collections.Generic;
using System.Linq;

namespace PersonRepository.Service
{
    public class ServiceRepository : IPersonRepository
    {
        private readonly PersonServiceClient _serviceProxy = new PersonServiceClient();

        public IEnumerable<Person> GetPeople()
        {
            return _serviceProxy.GetPeople();
        }

        public Person GetPerson(string lastName)
        {
            return _serviceProxy.GetPerson(lastName);
        }

        public void AddPerson(Person newPerson)
        {
            _serviceProxy.AddPerson(newPerson);
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            _serviceProxy.UpdatePerson(lastName, updatedPerson);
        }

        public void DeletePerson(string lastName)
        {
            _serviceProxy.DeletePerson(lastName);
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            _serviceProxy.UpdatePeople(updatedPeople.ToList());
        }
    }
}
