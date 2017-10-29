using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_EF : IPersonPhoneDAO
    {
        public void AddPhone(Phone phone)
        {
            using (PersonContext context = new PersonContext())
            {
                List<Phone> phoneList = context.Phones.ToList();
                phone.Id = (phoneList.Count == 0) ? 0 : phoneList.Max(x => x.Id) + 1;
                context.Phones.Add(phone);
                context.SaveChanges();
            }
        }

        public void Create(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                context.Persons.Add(p);
                context.SaveChanges();
            }
        }

        public void Delete(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                Person pToDel = context.Persons.First(x => x.Id == p.Id);
                context.Persons.Remove(pToDel);
                context.SaveChanges();
            }
        }

        public void DeletePhone(Phone phone)
        {
            using (PersonContext context = new PersonContext())
            {
                Phone phoneTodel = context.Phones.First(x => x.Id == phone.Id);
                context.Phones.Remove(phoneTodel);
                context.SaveChanges();
            }
        }

        public List<Person> Read()
        {
            using (PersonContext context = new PersonContext())
            {
                return context.Persons.ToList();
            }
        }

        public Person ReadById(int id)
        {
            using (PersonContext context = new PersonContext())
            {
                Person person = context.Persons.ToList().Find(x => x.Id == id);
                person.Phones = context.Phones.Where(x => x.PersonId == id).ToList();
                return person;
            }
        }

        public void Update(Person p)
        {
            using (PersonContext context = new PersonContext())
            {
                Person original = context.Persons.FirstOrDefault(x => x.Id == p.Id);
                context.Entry(original).CurrentValues.SetValues(p);
                context.SaveChanges();
            }
        }

        public void UpdatePhone(Phone phone)
        {
            using (PersonContext context = new PersonContext())
            {
                Phone original = context.Phones.FirstOrDefault(x => x.Id == phone.Id);
                context.Entry(original).CurrentValues.SetValues(phone);
                context.SaveChanges();
            }
        }
    }
}
