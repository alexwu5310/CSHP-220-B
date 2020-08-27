using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteProject1.Db;

namespace WebSiteProject1
{
    public class UserClassRepository
    {
        public void Add(int classId, int userId)
        {
            var userClassDb = ToDbModel(classId, userId);

            DatabaseManager.Instance.UserClass.Add(userClassDb);
            DatabaseManager.Instance.SaveChanges();
        }
        private UserClass ToDbModel(int classId, int userId)
        {
            var userClassDb = new UserClass
            {
                 ClassId = classId,
                 UserId = userId
            };

            return userClassDb;
        }

        public class StudebtClassesModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public StudebtClassesModel[] GetAll(int userId)
        {
            var myClassCollection = DatabaseManager.Instance.UserClass
                .Where(t => t.UserId == userId)
                .Select(t => new UserClass
                {
                    UserId = t.UserId,
                    ClassId = t.ClassId
                })
                .ToArray();

            var myClasses = new StudebtClassesModel[myClassCollection.Length];
            var index = 0;
            foreach(var userClass in myClassCollection)
            {
                var studentClass = DatabaseManager.Instance.Class.FirstOrDefault(t => t.ClassId == userClass.ClassId);

                var studentClassModel = new StudebtClassesModel
                {
                    Id = studentClass.ClassId,
                    Name = studentClass.ClassName,
                    Description = studentClass.ClassDescription,
                    Price = studentClass.ClassPrice
                };
                myClasses[index] = studentClassModel;
                index++;
            }

            return myClasses;
        }
    }
}
