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
        public static void AddUser(User user)
        {
            using (var context = new AssistanceOnlineContext())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }
    }
}
