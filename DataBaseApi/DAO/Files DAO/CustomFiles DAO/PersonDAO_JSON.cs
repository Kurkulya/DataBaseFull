using DataBaseApi.Api.LibraryFiles_DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    class PersonDAO_JSON : PersonDAO_Files
    {
        public PersonDAO_JSON() : base(@"E:\ORT_1708\C#\Data Bases\DataBase\DataBaseApi\DataBase\Persons.json")
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
            string line = File.ReadAllText(path);
            if (line.Length != 0)
            {
                line = (line.Remove(0, line.IndexOf('[') + 1));
                line = line.Remove(line.Length - 2, 2);
            }
            int i = 0;
            while (i < line.Length)
            {
                string str = "";
                while (line.ElementAt(i) != ']')
                {
                    str += line.ElementAt(i++);
                }
                str += line.ElementAt(i++);
                str += line.ElementAt(i++);
                i++;
                people.Add(FromJSON(str));
            }
            return people;

        }


        protected override void Write(List<Person> people)
        {
            StreamWriter file = new StreamWriter(path);
            file.Write("{ Persons : [");
            for (int i = 0; i < people.Count; i++)
            {
                file.Write(ToJSON(people.ElementAt(i)) + ((i != (people.Count - 1)) ? "," : ""));
            }
            file.Write("]}");
            file.Close();
        }


        private string ToJSON(Person person)
        {
            string str = "{";
            str += $"Id: {person.Id},";
            str += $"FirstName: {person.FirstName},";
            str += $"LastName: {person.LastName},";
            str += $"Age: {person.Age},";
            str += $"Phones : [";
            foreach(Phone phone in person.Phones)
            {
                str += "{";
                str += $"Id: {phone.Id},";
                str += $"Number: {phone.Number},";
                str += $"PersonId: {phone.PersonId}";
                str += "},";
            }
            str.TrimEnd(',');
            str += $"]";
            str += "}";
            return str;
        }
        private Person FromJSON(string json_string)
        {
            Person person = new Person();
            Phone phone = null;
            bool phones = false;
            string[] args = json_string.Split(',', '}', '{',']');
            foreach(string str in args)
            {
                if(str != "")
                {
                    string[] keyVal = str.Split(':');
                    keyVal = keyVal.Select(x => x.Trim()).ToArray();
                    if (phones == false)
                    {
                        switch (keyVal[0])
                        {
                            case "Id": person.Id = Convert.ToInt32(keyVal[1]); break;
                            case "FirstName": person.FirstName = keyVal[1]; break;
                            case "LastName": person.LastName = keyVal[1]; break;
                            case "Age": person.Age = Convert.ToInt32(keyVal[1]); break;
                            case "Phones": phones = true; break;
                        }
                    }
                    else
                    {                      
                        switch (keyVal[0])
                        {
                            case "Id":          phone = new Phone();
                                                phone.Id = Convert.ToInt32(keyVal[1]); break;
                            case "Number":      phone.Number = keyVal[1]; break;
                            case "PersonId":    phone.PersonId = Convert.ToInt32(keyVal[1]);
                                                person.Phones.Add(phone); break;
                        }
                    }
                }
            }
            return person;
        }

    }
}
