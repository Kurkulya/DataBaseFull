using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Api.LibraryFiles_DAO
{
    abstract public class PersonDAO_Files : IPersonPhoneDAO
    {
        protected string path = "";
        public PersonDAO_Files(string path)
        {
            this.path = path;
        }

        public void Create(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.Id == person.Id);
            if (add == null)
            {
                people.Add(person);
                people.Sort(Person.CompareById);
            }
            Write(people);
        }

        public void Delete(Person person)
        {
            List<Person> people = Load();
            Person del = people.Find((x) => x.Id == person.Id);
            if (del != null)
            {
                people.Remove(del);
            }
            Write(people);
        }
      
        public void Update(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.Id == person.Id);
            if (add != null)
            {
                int i = people.IndexOf(add);
                people.ElementAt(i).FirstName = person.FirstName;
                people.ElementAt(i).LastName = person.LastName;
                people.ElementAt(i).Age = person.Age;
            }
            Write(people);
        }

        public List<Person> Read()
        {
            return Load();
        }

        abstract protected List<Person> Load();
        abstract protected void Write(List<Person> people);

        public Person ReadById(int id)
        {
            return Load().FirstOrDefault(x => x.Id == id);
        }

        public void UpdatePhone(Phone phone)
        {
            List<Person> people = Load();
            people.FirstOrDefault(x => x.Id == phone.PersonId).Phones.FirstOrDefault(x => x.Id == phone.Id).Number = phone.Number;
            Write(people);
        }

        public void DeletePhone(Phone phone)
        {
            List<Person> people = Load();
            people.FirstOrDefault(x => x.Id == phone.PersonId).Phones.RemoveAll(x => x.Id == phone.Id);
            Write(people);
        }

        public void AddPhone(Phone phone)
        {
            List<Person> people = Load();
            List<Phone> phones = people.FirstOrDefault(x => x.Id == phone.PersonId).Phones;
            phone.Id = (phones.Count == 0) ? 0 : phones.Max(x =>x.Id) + 1;
            phones.Add(phone);
            Write(people);
        }
    }
}
