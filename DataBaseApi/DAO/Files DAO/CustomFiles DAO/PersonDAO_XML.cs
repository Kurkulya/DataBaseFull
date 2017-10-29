using DataBaseApi.Api.LibraryFiles_DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_XML : PersonDAO_Files
    {

        public PersonDAO_XML() : base(@"E:\ORT_1708\C#\Data Bases\DataBase\DataBaseApi\DataBase\Persons.xml")
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
            bool read = false;
            string request = "";
            foreach(string line in lines)
            {
                if (read == true)
                    request += line;

                if (line == "\t<Person>")
                {
                    read = true;
                }
                else if (line == "\t</Person>")
                {
                    read = false;
                    people.Add(FromXML(request));
                    request = "";
                }
            }            
            return people;
        }
   

        protected override void Write(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine("<Persons>");
            foreach (Person person in people)
            {
                file.WriteLine(ToXML(person));
            }
            file.WriteLine("</Persons>");
            file.Close();

        }

        private string ToXML(Person person)
        {
            string str = "\t<Person>\n";
            str += $"\t\t<Id>{person.Id}</Id>\n";
            str += $"\t\t<FirstName>{person.FirstName}</FirstName>\n";
            str += $"\t\t<LastName>{person.LastName}</LastName>\n";
            str += $"\t\t<Age>{person.Age}</Age>\n";
            str += "\t\t<Phones>\n";
            foreach (Phone phone in person.Phones)
            {
                str += "\t\t\t<Phone>\n";
                str += $"\t\t\t\t<Id>{phone.Id}</Id>\n";
                str += $"\t\t\t\t<Number>{phone.Number}</Number>\n";
                str += $"\t\t\t\t<PersonId>{phone.PersonId}</PersonId>\n";
                str += "\t\t\t</Phone>\n";
            }
            str += "\t\t</Phones>\n";
            str += "\t</Person>";
            return str;
        }
        private Person FromXML(string str)
        {
            Person person = new Person();
            Phone phone = null;
            str = str.Replace("\t", "");
            List<string> strings = str.Split('<', '>').ToList();
            strings.RemoveAll(x => x == "");
            person.Id = Int32.Parse(strings[1]);
            person.FirstName = strings[4];
            person.LastName = strings[7];
            person.Age = Int32.Parse(strings[10]);
            strings.RemoveRange(0, 14);
            strings.RemoveAll(x => x == "/Phone" || x == "Phone" || x == "/Phones" || x == "/Person");
            for (int i = 0; i < strings.Count; i+=3)
            {
                if(strings[i] == "Id")
                {
                    phone = new Phone();
                    phone.Id = Convert.ToInt32(strings[i + 1]);
                }
                else if(strings[i] == "Number")
                {
                    phone.Number = strings[i + 1];
                }
                else if(strings[i] == "PersonId")
                {
                    phone.PersonId = Convert.ToInt32(strings[i + 1]);
                    person.Phones.Add(phone);
                }
            }
            return person;
        }

    }
}
