using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_Mock : IPersonDAO
    {
        private class Data
        {
            public string fn;
            public string ln;
            public int age;

            public Data()
            {
            }

            public Data(string fn, string ln, int age)
            {
                this.fn = fn;
                this.ln = ln;
                this.age = age;
            }
        }

        Dictionary<int, Data> people;

        public PersonDAO_Mock()
        {
            people = new Dictionary<int, Data>();
 
            people.Add(1, new Data("Hermione", "Granger", 21));
            people.Add(2, new Data("Ron", "Weasley", 22));
            people.Add(10, new Data("Lord", "Voldemort", 112));
            people.Add(145, new Data("Severus", "Snape", 45));
            people.Add(1318, new Data("Harry", "Potter", 20));
        }

        public void Create(Person p)
        {
            people.Add(p.Id, new Data(p.FirstName, p.LastName, p.Age));
        }

        public void Delete(Person p)
        {
            people.Remove(p.Id);
        }

        public List<Person> Read()
        {
            List<Person> persons = new List<Person>();
            foreach (var p in people)
            {
                persons.Add(new Person(p.Key, p.Value.fn, p.Value.ln, p.Value.age));
            }


            return persons;
        }

        public void Update(Person p)
        {
            people[p.Id] = new Data(p.FirstName, p.LastName, p.Age);
        }
    }
}
