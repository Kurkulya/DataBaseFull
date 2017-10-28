using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    public class DBFactory
    {
        public static IPersonPhoneDAO GetInstance(string type)
        {
            IPersonPhoneDAO db = null;

            switch(type)
            {
                //case "MS SQL": db = new PersonDAO_MsSQL(); break;
                //case "MY SQL": db = new PersonDAO_MySQL(); break;
                //case "H2": db = new PersonDAO_H2(); break;
                //case "MONGODB": db = new PersonDAO_MONGODB(); break;
                //case "CSV": db = new PersonDAO_CSV(); break;
                //case "JSON": db = new PersonDAO_JSON(); break;
                //case "XML": db = new PersonDAO_XML(); break;
                //case "YAML": db = new PersonDAO_YAML(); break;
                //case "CSV_L": db = new PersonDAO_CSV_L(); break;
                //case "JSON_L": db = new PersonDAO_JSON_L(); break;
                //case "XML_L": db = new PersonDAO_XML_L(); break;
                //case "YAML_L": db = new PersonDAO_YAML_L(); break;
                //case "MS SQL EF": db = new PersonDAO_EF(); break;
                //case "BIN": db = new PersonDAO_Binary(); break;
                //case "BIN_L": db = new PersonDAO_Binary_L(); break;
                case "MOCK": db = new PersonDAO_Mock(); break;
            }

            return db;
        }
    }
}
