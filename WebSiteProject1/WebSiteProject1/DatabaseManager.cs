using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteProject1.Db;

namespace WebSiteProject1
{
    public class DatabaseManager
    {
        private static readonly minicstructorContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new minicstructorContext();
        }

        // Provide an accessor to the database
        public static minicstructorContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
