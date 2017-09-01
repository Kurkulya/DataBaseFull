using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.H2;
using java.sql;

namespace DataBaseWPF
{
    class PersonH2 : IPersonDAO
    {
        Connection connection = null;
        Statement state;
        string tableName = "";
        public PersonH2()
        {
            string connectionH2 = "jdbc:h2:tcp://localhost/~/test";
            string user = "sa";
            string pass = "";

            tableName = "person";

            org.h2.Driver.load();
            connection = DriverManager.getConnection(connectionH2, user, pass);
            state = connection.createStatement();
            //connection = new H2Connection(connectionH2, user, pass);
        }


        public void Create(Person person)
        {
            
            //connection.Open();
            //H2Command cmd = new H2Command(connection);
            //cmd.CommandText = $"insert into {tableName} (Id, FirstName, LastName, Age) " +
            //             $"values ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})";

            //cmd.ExecuteNonQuery();

            //connection.Close();

            string cmd = $"insert into {tableName} (Id, FirstName, LastName, Age) " +
                         $"values ({person.Id}, '{person.FirstName}', '{person.LastName}', {person.Age})";
            state.executeQuery(cmd);
            connection.close();
        }

        public void Delete(Person person)
        {
            //Statement state = connection.createStatement();

            //string cmd = $"Delete FROM {tableName} " +
            //             $"WHERE Id = {person.Id};";
            //state.executeQuery(cmd);

            //connection.close();
        }

        public List<Person> Read()
        {
            // state = connection.createStatement();

            List<Person> listPerson = new List<Person>();

            string cmd = $"SELECT * FROM {tableName};";
            //ResultSet rs = state.executeQuery(cmd);
            //while (rs.next() == true)
            //{
            //    listPerson.Add(new Person(rs.getInt(0),rs.getString(1),rs.getString(2),rs.getInt(3)));
            //}
            //connection.close();

            return listPerson;
        }

        public void Update(Person person)
        {
            //Statement state = connection.createStatement();

            //string cmd = $"UPDATE {tableName} " +
            //             $"SET FirstName = '{person.FirstName}', LastName='{person.LastName}', Age={person.Age} " +
            //             $"WHERE Id = {person.Id};";
            //state.executeQuery(cmd);

            //connection.close();
        }
    }
}
