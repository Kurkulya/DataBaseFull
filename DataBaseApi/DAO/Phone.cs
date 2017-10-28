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

        public Phone(string number)
        {
            Number = number;
        }

        public Phone(int id, string number)
        {
            Id = id;
            Number = number;
        }
    }
}
