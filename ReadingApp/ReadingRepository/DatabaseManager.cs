using System;
using System.Collections.Generic;
using System.Text;
using ReadingDB;

namespace ReadingRepository
{
    public class DatabaseManager
    {
        private static readonly ReadingContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ReadingContext();
        }

        // Provide an accessor to the database
        public static ReadingContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
