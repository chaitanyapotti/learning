using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PersonRepository.Interface;

namespace People.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PersonService : IPersonService
    {

        public List<Person> GetPeople()
        {
            var p = new List<Person>()
            {
                new Person() { FirstName="John", LastName="Koenig",
                    StartDate = new DateTime(1975, 10, 17), Rating=6 },
                new Person() { FirstName="Dylan", LastName="Hunt",
                    StartDate = new DateTime(2000, 10, 2), Rating=8 },
                new Person() { FirstName="John", LastName="Crichton",
                    StartDate = new DateTime(1999, 3, 19), Rating=7 },
                new Person() { FirstName="Dave", LastName="Lister",
                    StartDate = new DateTime(1988, 2, 15), Rating=9 },
                new Person() { FirstName="John", LastName="Sheridan",
                    StartDate = new DateTime(1994, 1, 26), Rating=6 },
                new Person() { FirstName="Dante", LastName="Montana",
                    StartDate = new DateTime(2000, 11, 1), Rating=5 },
                new Person() { FirstName="Isaac", LastName="Gampu",
                    StartDate = new DateTime(1977, 9, 10), Rating=4 }
            };
            return p;
        }

        public Person GetPerson(string lastName)
        {
            var p = new List<Person>()
            {
                new Person() { FirstName="John", LastName="Koenig",
                    StartDate = new DateTime(1975, 10, 17), Rating=6 },
                new Person() { FirstName="Dylan", LastName="Hunt",
                    StartDate = new DateTime(2000, 10, 2), Rating=8 },
                new Person() { FirstName="John", LastName="Crichton",
                    StartDate = new DateTime(1999, 3, 19), Rating=7 },
                new Person() { FirstName="Dave", LastName="Lister",
                    StartDate = new DateTime(1988, 2, 15), Rating=9 },
                new Person() { FirstName="John", LastName="Sheridan",
                    StartDate = new DateTime(1994, 1, 26), Rating=6 },
                new Person() { FirstName="Dante", LastName="Montana",
                    StartDate = new DateTime(2000, 11, 1), Rating=5 },
                new Person() { FirstName="Isaac", LastName="Gampu",
                    StartDate = new DateTime(1977, 9, 10), Rating=4 }
            };

            Person selPerson = p.FirstOrDefault(s => s.LastName == lastName);
            return selPerson;
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePeople(List<Person> updatedPeople)
        {
            throw new NotImplementedException();
        }
    }
}
