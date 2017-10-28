using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseApi
{
    [Serializable]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [BsonId]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Phone> Phones { get; set; }

       public Person(int Id, string FirstName, string LastName, int Age)
        {
            Init(Id, FirstName, LastName, Age);
        }
        public Person()
        {
            Phones = new List<Phone>();
        }
        public void Init(int Id, string FirstName, string LastName, int Age)
        {
            Phones = new List<Phone>();
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }

        public static int CompareById(Person x, Person y)
        {
            if (x.Id > y.Id)
                return 1;
            else if (x.Id < y.Id)
                return -1;
            else
                return 0;
        }

    }
}