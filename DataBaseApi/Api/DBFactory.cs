using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    public class DBFactory
    {
        public static IPersonDAO GetInstance(int type)
        {
            IPersonDAO db = null;

            switch(type)
            {
                case 0: db = new PersonDAOMsSQL(); break;
                case 1: db = new PersonDAOMySQL(); break;
                case 2: db = new PersonDAOH2(); break;
            }

            return db;
        }
    }
}
