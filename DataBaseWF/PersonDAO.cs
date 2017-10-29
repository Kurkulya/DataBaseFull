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

        public void AddPhone(Phone phone)
        {
            db.AddPhone(phone);
        }

        public void DeletePhone(Phone phone)
        {
            db.DeletePhone(phone);
        }

        public void UpdatePhone(Phone phone)
        {
            db.UpdatePhone(phone);
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
