using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseWPF
{
    public class DBImpl
    {
        public static IPersonDAO GetInstance(int type)
        {
            IPersonDAO db = null;

            switch(type)
            {
                case 0: db = new PersonMsSQL(); break;
                case 1: db = new PersonMySQL(); break;
                //case "H2": db = new PersonH2(); break;
            }

            return db;
        }
    }
}
