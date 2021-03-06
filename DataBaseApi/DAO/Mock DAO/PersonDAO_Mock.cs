﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_Mock : IPersonPhoneDAO
    {
        private class Data
        {
            public string fn;
            public string ln;
            public int age;
            public List<Phone> phones;

            public Data()
            {
            }

            public Data(string fn, string ln, int age)
            {
                phones = new List<Phone>();
                this.fn = fn;
                this.ln = ln;
                this.age = age;
            }
        }

        Dictionary<int, Data> people;
        Dictionary<Phone, int> phones;

        public PersonDAO_Mock()
        {
            people = new Dictionary<int, Data>();
            phones = new Dictionary<Phone, int>();

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
            List<Phone> phones = people[p.Id].phones;
            people[p.Id] = new Data(p.FirstName, p.LastName, p.Age);
            people[p.Id].phones = phones;
        }

        public Person ReadById(int id)
        {
            Person person = new Person(id, people[id].fn, people[id].ln, people[id].age);
            person.Phones = phones.Where(x => x.Value == id).Select(x => x.Key).ToList();
            return person;
        }

        public void UpdatePhone(Phone phone)
        {
            phones.Keys.FirstOrDefault(x => x.Id == phone.Id).Number = phone.Number;
        }

        public void DeletePhone(Phone phone)
        {
            phones.Remove(phones.FirstOrDefault(x => x.Key.Id == phone.Id).Key);
        }

        public void AddPhone(Phone phone)
        {
            phone.Id = (phones.Count == 0) ? 0 : phones.Max(x => x.Key.Id) + 1;
            phones.Add(phone, phone.PersonId);
        }
    }
}
