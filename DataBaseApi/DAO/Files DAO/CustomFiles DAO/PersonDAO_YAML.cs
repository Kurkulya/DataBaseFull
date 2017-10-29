using DataBaseApi.Api.LibraryFiles_DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_YAML : PersonDAO_Files
    {
        public PersonDAO_YAML() : base(@"E:\ORT_1708\C#\Data Bases\DataBase\DataBaseApi\DataBase\Persons.yaml")
        {
        }

        protected override List<Person> Load()
        {
            List<Person> people = new List<Person>();
            FileStream fs;
            if (File.Exists(path) == false)
            {
                fs = File.Create(path);
                fs.Close();
            }
            List<string> lines = File.ReadAllLines(path).ToList();
            string request = "";
            foreach (string line in lines)
            {
                if (line.StartsWith("- Id:"))
                {
                    if (request != "")
                    {
                        people.Add(FromYAML(request));
                        request = "";
                    }
                }
                request += line;
            }

            if (request != "")
                people.Add(FromYAML(request));

            return people;
        }

        protected override void Write(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (Person person in people)
            {
                file.WriteLine(ToYAML(person));
            }
            file.Close();
        }


        private string ToYAML(Person person)
        {
            string str = "";
            str += $"- Id: {person.Id} \n";
            str += $"\tFirstName: {person.FirstName} \n";
            str += $"\tLastName: {person.LastName} \n";
            str += $"\tAge: {person.Age} \n";
            str += $"\tPhones: \n";
            foreach (Phone phone in person.Phones)
            {
                str += $"\t- PhoneId: {phone.Id} \n";
                str += $"\t\tNumber: {phone.Number} \n";
                str += $"\t\tPersonId: {phone.PersonId} \n";
            }
            return str;
        }
        private Person FromYAML(string yaml_string)
        {
            Person person = new Person();
            Phone phone = null;
            List<string> args = yaml_string.Replace("\t", "").Split('-', ' ').ToList();
            args.RemoveAll(x => x == "");
            person.Id = Int32.Parse(args[1].Trim());
            person.FirstName = args[3].Trim();
            person.LastName = args[5].Trim();
            person.Age = Int32.Parse(args[7].Trim());
            args.RemoveRange(0, 9);
            for (int i = 0; i < args.Count; i+=2)
            {
                if(args[i] == "PhoneId:")
                {
                    phone = new Phone();
                    phone.Id = Int32.Parse(args[i + 1].Trim());
                }
                else if(args[i] == "Number:")
                {
                    phone.Number = args[i + 1].Trim();
                }
                else if (args[i] == "PersonId:")
                {
                    phone.PersonId = Int32.Parse(args[i + 1].Trim());
                    person.Phones.Add(phone);
                }
            }           
            return person;
        }

    }
}
