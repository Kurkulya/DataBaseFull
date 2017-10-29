using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.Api.LibraryFiles_DAO
{
    abstract public class PersonDAO_SQL : IPersonPhoneDAO
    {
        protected string tableName = "";
        protected string phoneTable = "";

        public PersonDAO_SQL()
        {
            tableName = "person";
            phoneTable = "phones";
        }

        public void Create(Person person)
        {
            OpenConnection();
            string cmd =
                $"INSERT INTO {tableName} (Id, FirstName, LastName, Age) " +
                $"VALUES ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public void Delete(Person person)
        {
            OpenConnection();
            string cmd =
                $"Delete FROM {phoneTable} " +
                $"WHERE Person_Id = {person.Id};";
            ExecuteCommand(cmd);
            cmd =
                $"Delete FROM {tableName} " +
                $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public List<Person> Read()
        {            
            OpenConnection();
            string cmd = $"SELECT * FROM {tableName};";
            List<Person> listPerson = ReadData(cmd);
            CloseConnection();
            return listPerson;
        }

        public void Update(Person person)
        {
            OpenConnection();
            string cmd =
                $"UPDATE {tableName} " +
                $"SET FirstName = '{person.FirstName}', LastName='{person.LastName}', Age={person.Age} " +
                $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        abstract protected void CloseConnection();
        abstract protected void OpenConnection();
        abstract protected void ExecuteCommand(string cmd);
        abstract protected List<Person> ReadData(string cmdPerson);
        abstract protected List<Phone> ReadPhones(string cmdPhone);

        public Person ReadById(int id)
        {
            OpenConnection();
            string cmdPerson = $"SELECT * FROM {tableName} WHERE Id={id}";
            string cmdPhone = $"SELECT * FROM {phoneTable} WHERE Person_Id={id}";
            Person person = ReadData(cmdPerson).First();
            person.Phones = ReadPhones(cmdPhone);
            CloseConnection();
            return person;
        }

        public void UpdatePhone(Phone phone)
        {
            OpenConnection();
            string cmd =
                $"UPDATE {phoneTable} " +
                $"SET Phone = '{phone.Number}' " +
                $"WHERE Id = {phone.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public void DeletePhone(Phone phone)
        {
            OpenConnection();
            string cmd =
                $"Delete FROM {phoneTable} " +
                $"WHERE Id = {phone.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public void AddPhone(Phone phone)
        {
            OpenConnection();
            string cmd =
                $"INSERT INTO {phoneTable} (Phone, Person_Id) " +
                $"VALUES ('{phone.Number}', {phone.PersonId})";
            ExecuteCommand(cmd);
            CloseConnection();
        }
    }
}
