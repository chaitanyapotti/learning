using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class PeopleRepository
    {
        //We are performing crud operations. i.e., create, read, update, delete. Basics of any data layer
        public List<Person> People => new List<Person>
        {
            new Person{Firstname = "John", LastName = "Koenig", StartDate= DateTime.Parse("10/17/1975"), Rating = 1},
            new Person{Firstname = "Dylan", LastName = "Hunt", StartDate= DateTime.Parse("10/02/2000"), Rating = 1},
            new Person{Firstname = "John", LastName = "Crichton", StartDate= DateTime.Parse("03/19/1999"), Rating = 1},
            new Person{Firstname = "Dave", LastName = "Lister", StartDate= DateTime.Parse("02/05/1998"), Rating = 1},
            new Person{Firstname = "John", LastName = "Sheridan", StartDate= DateTime.Parse("01/26/1994"), Rating = 1},
            new Person{Firstname = "Dante", LastName = "Montana", StartDate= DateTime.Parse("11/01/2000"), Rating = 1},
            new Person{Firstname = "Issac", LastName = "Gampu", StartDate= DateTime.Parse("09/10/1977"), Rating = 1}
        };

        public Person[] People2 => new[]
        {
            new Person{Firstname = "John", LastName = "Koenig", StartDate= DateTime.Parse("10/17/1975"), Rating = 1},
            new Person{Firstname = "Dylan", LastName = "Hunt", StartDate= DateTime.Parse("10/02/2000"), Rating = 1},
            new Person{Firstname = "John", LastName = "Crichton", StartDate= DateTime.Parse("03/19/1999"), Rating = 1},
            new Person{Firstname = "Dave", LastName = "Lister", StartDate= DateTime.Parse("02/05/1998"), Rating = 1},
            new Person{Firstname = "John", LastName = "Sheridan", StartDate= DateTime.Parse("01/26/1994"), Rating = 1},
            new Person{Firstname = "Dante", LastName = "Montana", StartDate= DateTime.Parse("11/01/2000"), Rating = 1},
            new Person{Firstname = "Issac", LastName = "Gampu", StartDate= DateTime.Parse("09/10/1977"), Rating = 1}
        };
        public Person[] People3 => new[]
        {
            new Person{Firstname = "John", LastName = "Koenig", StartDate= DateTime.Parse("10/17/1975"), Rating = 1},
            new Person{Firstname = "Dylan", LastName = "Hunt", StartDate= DateTime.Parse("10/02/2000"), Rating = 2},
            new Person{Firstname = "John", LastName = "Crichton", StartDate= DateTime.Parse("03/19/1999"), Rating = 1},
            new Person{Firstname = "Dave", LastName = "Lister", StartDate= DateTime.Parse("02/05/1998"), Rating = 1},
            new Person{Firstname = "John", LastName = "Sheridan", StartDate= DateTime.Parse("01/26/1994"), Rating = 1},
            new Person{Firstname = "Dante", LastName = "Montana", StartDate= DateTime.Parse("11/01/2000"), Rating = 1},
            new Person{Firstname = "Issac", LastName = "Gampu", StartDate= DateTime.Parse("09/10/1977"), Rating = 1}
        };

        public Person GetPerson(string lastName) => People.First(x => x.LastName == lastName);

        public void AddPerson(Person newPerson)
        {
            //var booleanx = StructuralComparisons.StructuralComparer.Compare(People, newPerson);
            People.Add(newPerson);
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            var person = People.FirstOrDefault(x => x.LastName == lastName);
            int index = People.IndexOf(person);
            if(index != -1) People[index] = updatedPerson;
        }

        public void DeletePerson(string lastName)
        {
            var person = People.FirstOrDefault(x => x.LastName == lastName);
            People.Remove(person);
        }

        public void UpdatePeople(List<Person> updatedPeople)
        {
            People.Clear();
            People.AddRange(updatedPeople);
            //People.Add(updatedPeople);
        }
        public void SortPeople(List<Person> updatedPeople)
        {
            People.Clear();
            People.AddRange(updatedPeople);
            People.Sort(PersonComparer.Instance);
            //People.Add(updatedPeople);
        }
    }
}
