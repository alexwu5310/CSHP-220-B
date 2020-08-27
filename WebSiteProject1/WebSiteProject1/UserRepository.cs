using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteProject1.Db;
using WebSiteProject1.Models;

namespace WebSiteProject1
{
    public class UserRepository
    {
        public Register Add(Register userModel)
        {
            var userDb = ToDbModel(userModel);

            DatabaseManager.Instance.User.Add(userDb);
            DatabaseManager.Instance.SaveChanges();

            userModel = new Register
            {
                Id = userDb.UserId,
                Email = userDb.UserEmail,
                Password = userDb.UserPassword,
                isAdmin = userDb.UserIsAdmin
            };
            return userModel;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseManager.Instance.User
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                                      && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }
            
            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        private User ToDbModel(Register userModel)
        {
            var userDb = new User
            {
                UserId = userModel.Id,
                UserEmail = userModel.Email,
                UserPassword = userModel.Password,
                UserIsAdmin = userModel.isAdmin
            };

            return userDb;
        }
    }
}
