using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.H2;

namespace DataBaseApi
{
    class PersonDAOH2 : IPersonDAO
    {
        H2Connection connection = null;
        string tableName = "";
        public PersonDAOH2()
        {
            string connectionH2 = "jdbc:h2:tcp://localhost/~/test";
            string user = "sa";
            string pass = "";

            tableName = "person";

            connection = new H2Connection(connectionH2, user, pass);
        }


        public void Create(Person person)
        {
            connection.Open();

            H2Command cmd = new H2Command(
                $"INSERT INTO [{tableName}] (Id, FirstName, LastName, Age) " +
                $"VALUES ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(Person person)
        {
            connection.Open();

            H2Command cmd = new H2Command(
                $"Delete FROM [{tableName}] " +
                $"WHERE Id = {person.Id};", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public List<Person> Read()
        {

            List<Person> listPerson = new List<Person>();

            connection.Open();
            H2Command cmd = new H2Command($"SELECT * FROM [{tableName}];", connection);
            H2DataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listPerson.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
            }
            reader.Close();

            connection.Close();
            return listPerson;
        }

        public void Update(Person person)
        {
            connection.Open();

            H2Command cmd = new H2Command(
                $"UPDATE [{tableName}] " +
                $"SET FirstName = '{person.FirstName}', LastName='{person.LastName}', Age={person.Age} " +
                $"WHERE Id = {person.Id};", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
