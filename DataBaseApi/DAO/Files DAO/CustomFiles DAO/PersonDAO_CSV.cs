using DataBaseApi.Api.LibraryFiles_DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_CSV : PersonDAO_Files
    {
        public PersonDAO_CSV() : base(@"E:\ORT_1708\C#\Data Bases\DataBase\DataBaseApi\DataBase\Persons.csv")
        {
        }

        protected override List<Person> Load()
        {
            List<Person> people = new List<Person>();
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
                people.Add(FromCSV(lines[i]));
            }
            return people;
        }


        protected override void Write(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine("Id, FirstName, LastName, Age, Phones");
            foreach (Person person in people)
            {
                file.WriteLine(ToCSV(person));
            }
            file.Close();
        }
       

        private string ToCSV(Person person)
        {
            string str = "";
            str += person.Id + ", ";
            str += person.FirstName + ", ";
            str += person.LastName + ", ";
            str += person.Age + ", ";
            str += "\"[";
            foreach (Phone phone in person.Phones)
            {
                str += "{";
                str += $"Id: {phone.Id},";
                str += $"Number: {phone.Number},";
                str += $"PersonId: {phone.PersonId}";
                str += "},";
            }
            str.TrimEnd(',');
            str += "]\"";
            return str;
        }

        private Person FromCSV(string csv_string)
        {
            Person person = new Person();
            Phone phone = new Phone();
            string[] phones = csv_string.Split('[')[1].Split('{','}',',');
            string[] args = csv_string.Split('[')[0].Split(',');

            person.Id = Int32.Parse(args[0].Trim());
            person.FirstName = args[1].Trim();
            person.LastName = args[2].Trim();
            person.Age = Int32.Parse(args[3].Trim());

            foreach (string str in phones)
            {
                if (str != "" && str != "]\"")
                {
                    string[] keyVal = str.Split(':');
                    keyVal = keyVal.Select(x => x.Trim()).ToArray();
                    switch (keyVal[0])
                    {
                        case "Id":
                            phone = new Phone();
                            phone.Id = Convert.ToInt32(keyVal[1]); break;
                        case "Number": phone.Number = keyVal[1]; break;
                        case "PersonId":
                            phone.PersonId = Convert.ToInt32(keyVal[1]);
                            person.Phones.Add(phone); break;
                    }
                }
            }
            return person;
        }
    }
}
