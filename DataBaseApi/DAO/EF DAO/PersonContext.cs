using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    public class PersonContext : DbContext
    {
        public PersonContext(): base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ORT_1708\C#\Data Bases\DataBase\DataBaseApi\DataBase\LocalDB_EF.mdf;Integrated Security=True;")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
