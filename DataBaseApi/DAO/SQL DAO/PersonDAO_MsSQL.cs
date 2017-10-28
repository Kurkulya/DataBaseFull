using DataBaseApi.Api.LibraryFiles_DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_MsSQL : PersonDAO_SQL
    {
        SqlConnection connection = null;
        public PersonDAO_MsSQL()
        {
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                             @"AttachDbFilename=E:\ORT_1708\C#\Data Bases\DataBase\DataBaseApi\DataBase\LocalDB.mdf;" +
                             @"Integrated Security=True";

            connection = new SqlConnection(strConn);
        }

        protected override void CloseConnection()
        {
            connection.Close();
        }

        protected override void OpenConnection()
        {
            connection.Open();
        }

        protected override void ExecuteCommand(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.ExecuteNonQuery();
        }

        protected override List<Person> ReadData(string cmdPerson)
        {
            SqlCommand personSql = new SqlCommand(cmdPerson, connection);
            SqlDataReader personReader = personSql.ExecuteReader();

            List<Person> listPerson = new List<Person>();
            while (personReader.Read())
            {
                listPerson.Add(new Person(personReader.GetInt32(0), personReader.GetString(1), personReader.GetString(2), personReader.GetInt32(3)));
            }
            personReader.Close();
            return listPerson;
        }

        protected override List<Phone> ReadPhones(string cmdPhone)
        {
            SqlCommand phoneSql = new SqlCommand(cmdPhone, connection);
            SqlDataReader phoneReader = phoneSql.ExecuteReader();

            List<Phone> phones = new List<Phone>();
            while (phoneReader.Read())
            {
                phones.Add(new Phone(phoneReader.GetInt32(0), phoneReader.GetString(1)));
            }
            phoneReader.Close();
            return phones;
        }
    }
}
