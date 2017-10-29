using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_MONGODB : IPersonPhoneDAO
    {
        IMongoCollection<Person> people = null;
        IMongoCollection<Phone> phones = null;
        public PersonDAO_MONGODB()
        {
            string strConn = @"mongodb://localhost:27017";

            MongoClient client = new MongoClient(strConn);
            IMongoDatabase database = client.GetDatabase("mongoPerson");
            people = database.GetCollection<Person>("people");
            phones = database.GetCollection<Phone>("phones");
        }

        public void AddPhone(Phone phone)
        {
            if (phones.Find(x => x.Id == phone.Id).ToList().Count == 0)
                phones.InsertOne(phone);
        }

        public void Create(Person person)
        {
            if (people.Find(x => x.Id == person.Id).ToList().Count == 0)
                people.InsertOne(person);
        }

        public void Delete(Person person)
        {
            people.DeleteOne(x => x.Id == person.Id);
        }

        public void DeletePhone(Phone phone)
        {
            phones.DeleteOne(x => x.Id == phone.Id);
        }

        public List<Person> Read()
        {
            List<Person> listPerson = new List<Person>();
            listPerson = people.Find(x => true).ToList();
            listPerson.Sort(Person.CompareById);
            return listPerson;
        }

        public Person ReadById(int id)
        {
            Person person = people.Find(x => x.Id == id).First();
            person.Phones = phones.Find(x => x.PersonId == id).ToList();
            return person;
        }

        public void Update(Person person)
        {
            people.ReplaceOne(x => x.Id == person.Id, person);
        }

        public void UpdatePhone(Phone phone)
        {
            phones.ReplaceOne(x => x.Id == phone.Id, phone);
        }
    }
}
