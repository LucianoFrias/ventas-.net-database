using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasDatabase.src.utils
{
    internal class DatabaseConfigReader
    {
        public string ConnectionString { get; set; }
            
        public DatabaseConfigReader()
        {
            ConnectionString = ConfigurationManager.AppSettings["databaseConnection"];
        }


    }
}
