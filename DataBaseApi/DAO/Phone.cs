using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    public class Phone
    {
        public int Id { get; set; }

        public string Number { get; set; }
        public int PersonId { get; set; }

        public Phone(string number, int personId)
        {
            Number = number;
            PersonId = personId;
        }

        public Phone(int id, string number, int personId)
        {
            Id = id;
            Number = number;
            PersonId = personId;
        }
    }
}
