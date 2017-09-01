using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWPF
{
    class PersonMySQL : IPersonDAO
    {
        MySqlConnection connection = null;
        string tableName = "";
        public PersonMySQL()
        {
            string MySQLconnString = @"Server=localhost;" +
                                     @"Database=bisser;" +
                                     @"Uid=root;" +
                                     @"Pwd=;";

            tableName = "person";
            connection = new MySqlConnection(MySQLconnString);
        }

        public void Create(Person person)
        {
            connection.Open();

            string cmd = $"INSERT INTO {tableName} (Id, FirstName, LastName, Age) " +
                         $"VALUES ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})";
            ExecuteCommand(cmd);

            connection.Close();
        }

        public void Delete(Person person)
        {
            connection.Open();

            string cmd = $"DELETE FROM {tableName} " +
                         $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);

            connection.Close();
        }

        public List<Person> Read()
        {
            List<Person> listPerson = new List<Person>();

            connection.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM {tableName};", connection);
            MySqlDataReader reader = cmd.ExecuteReader();

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

            string cmd = $"UPDATE {tableName} " +
                                $"SET FirstName = '{person.FirstName}', LastName='{person.LastName}', Age={person.Age} " +
                                $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);

            connection.Close();
        }

        private void ExecuteCommand(string commandText)
        {
            DbCommand command = new MySqlCommand();
            command = new MySqlCommand(commandText, connection);
            command.ExecuteNonQuery();
        }
    }
}
