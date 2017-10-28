using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{    
    public interface IPersonDAO
    {
        List<Person> Read();
        void Update(Person person);
        void Delete(Person person);
        void Create(Person person);
    }

    public interface IPersonPhoneDAO : IPersonDAO
    {
        Person ReadById(int id);
        void UpdatePhone(Person person, Phone phone);
        void DeletePhone(Person person, Phone phone);
        void AddPhone(Person person, Phone phone);
    }
}
