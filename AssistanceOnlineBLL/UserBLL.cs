using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistanceOnlineDAL;


namespace AssistanceOnlineBLL
{
    public static class UserBLL
    {
        public static bool AddUser(User user)
        {
            
            using (var context = new AssistanceOnlineContext())
            {
                if (context.User.Where(c => c.email == user.email).Any())
                {
                    return false;
                }
                else
                {
                    context.User.Add(user);
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public static User findUserById(int id)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    return context.User.Where(c => c.idUser == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static User findUserByToken(string token)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    return context.User.Where(c => c.keyToken == token).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int verifyUserLogin (string email, string password)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    if (context.User.Where(c => c.email == email && c.active == true).Any())
                    {
                        if (context.User.Where(c => c.email == email && c.password == password && c.active == true).Any())
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 3;
                    } 
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static User findUserByEmail(string email)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    return context.User.Where(c => c.email == email && c.active == true).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void updateUser(User user)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    var usuario = context.User.Where(c => c.idUser == user.idUser).FirstOrDefault();

                    usuario.active = user.active;
                    usuario.name = user.name;
                    usuario.lastName = user.lastName;
                    usuario.email = user.email;
                    usuario.keyToken = user.keyToken;
                    usuario.password = user.password;
                    usuario.modificationDate = DateTime.UtcNow;
                    
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
