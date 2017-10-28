using DataBaseApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    public class PersonDAO
    {
        IPersonPhoneDAO db = null;

        public void SetDataBase(string type)
        {
            db = DBFactory.GetInstance(type);
        }
  
        public PersonDAO(string type)
        {
            SetDataBase(type);
        }

        public void Create(Person person)
        {
            db.Create(person);
        }

        public void Delete(Person person)
        {
            db.Delete(person);
        }

        public List<Person> Read()
        {
            return db.Read();
        }

        public void AddPhone(Person person, Phone phone)
        {
            db.AddPhone(person, phone);
        }

        public void DeletePhone(Person person, Phone phone)
        {
            db.DeletePhone(person, phone);
        }

        public void UpdatePhone(Person person, Phone phone)
        {
            db.UpdatePhone(person, phone);
        }


        public Person ReadPerson(int id)
        {
            return db.ReadById(id);
        }

        public void Update(Person person)
        {
            db.Update(person);
        }
    }
}
