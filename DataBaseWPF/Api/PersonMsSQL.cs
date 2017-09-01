using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWPF
{
    class PersonMsSQL : IPersonDAO
    {
        SqlConnection connection = null;
        string tableName = "";
        public PersonMsSQL()
        {
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                             @"AttachDbFilename=E:\C# 1708\DataBaseWPF\DataBaseWPF\DataBase\LocalDB.mdf;" +
                             @"Integrated Security=True";

            tableName = "person";
            connection = new SqlConnection(strConn);
        }

        public void Create(Person person)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand(
                $"INSERT INTO [{tableName}] (Id, FirstName, LastName, Age) " +
                $"VALUES ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(Person person)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand(
                $"Delete FROM [{tableName}] " +
                $"WHERE Id = {person.Id};", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public List<Person> Read()
        {
            List<Person> listPerson = new List<Person>();

            connection.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [{tableName}];", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listPerson.Add(new Person(reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetInt32(3)));
            }
            reader.Close();

            connection.Close();
            return listPerson;
        }

        public void Update(Person person)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand(
                $"UPDATE [{tableName}] " +
                $"SET FirstName = '{person.FirstName}', LastName='{person.LastName}', Age={person.Age} " +
                $"WHERE Id = {person.Id};", connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
