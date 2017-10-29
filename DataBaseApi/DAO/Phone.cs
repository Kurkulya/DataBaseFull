using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
     
    [Serializable]
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonId]
        public int Id { get; set; }

        public string Number { get; set; }
        public int PersonId { get; set; }

        public Phone(string number, int personId)
        {
            Number = number;
            PersonId = personId;
        }

        public Phone()
        {
        }

        public Phone(int id, string number, int personId)
        {
            Id = id;
            Number = number;
            PersonId = personId;
        }
    }
}
