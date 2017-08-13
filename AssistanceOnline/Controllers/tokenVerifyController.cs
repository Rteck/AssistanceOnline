using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AssistanceOnlineUtilities;
using AssistanceOnlineBLL;
using AssistanceOnlineDAL;
using System.Web.Http.Results;

namespace AssistanceOnline.Controllers
{
    public class tokenVerifyController : ApiController
    {
        [HttpGet]
        public RedirectResult emailConfirmation(string tk)
        {
            User user = UserBLL.findUserByToken(tk);
           

            if (Utilities.activeUserToken(tk))
            {
                user.active = true;
                UserBLL.updateUser(user);

                

                return Redirect("http://localhost:56432/Home?fk="+user.keyToken);
            }
            else
            {
                return Redirect("");
            }
        }
    }
}
