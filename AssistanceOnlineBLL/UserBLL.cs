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
    }
}
