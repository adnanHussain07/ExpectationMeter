using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpectationMeter.DataServices;

using ExpectationMeter.CommonCode;

namespace ExpectationMeter.Models.Services
{
    public class DMLOperations
    {
        private static DMLOperations _Instance;
        public static DMLOperations Instance
        {

            get
            {

                if (_Instance == null)
                {
                    _Instance = new DMLOperations();
                }
                return (_Instance);
            }
        }

        private DMLOperations()
        {
        }

        #region services

        public void AddUser(User user)
        {

            using (var context = DataContextHelper.GetCPDataContext())
            {
                context.Insert(user);
            }

        }
        
        public void DeleteUser(int userID)
        {
            using (var context = DataContextHelper.GetCPDataContext())
            {
                context.Execute("Delete From Users where UserID=@0", userID);
            }

        }
            public void UpdateUser(User user)
        {

            using (var context = DataContextHelper.GetCPDataContext())
            {
                context.Update(user);
            }
        }

        public User GetUser(int userID)
        {

            using (var context = DataContextHelper.GetCPDataContext())
            {
                var sql = PetaPoco.Sql.Builder.Select("*").From("Users").Where("UserID=@0", userID);
                      return context.Fetch<User>(sql).FirstOrDefault();
            }


        }

        public List<User> GetUsers()
        {

            using (var context = DataContextHelper.GetCPDataContext())
            {
                var sql = PetaPoco.Sql.Builder.Select("*").From("Users");
                      return context.Fetch<User>(sql).ToList();
            }


        }
        #endregion
    }
}
