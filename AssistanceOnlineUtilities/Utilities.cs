using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AssistanceOnlineBLL;
using AssistanceOnlineDAL;
using System.Net.Mail;

namespace AssistanceOnlineUtilities
{
    public static class Utilities
    {
        public static bool verifyReCapchat(string response)
        {
            try
            {
                string secretKey = KeyBLL.selectKey("secretKey").value;
                var client = new WebClient();

                var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
                var obj = JObject.Parse(result);
                return (bool)obj.SelectToken("success");
            }
            catch (WebException ex)
            {

                throw ex;
            }
        }

        public static bool sendEmailVerification(User user)
        {
            string subject = "Account verification";
            string body = "Hola";
            List<string> to = new List<string>();
            to.Add(user.email);
            return sendEmail(subject,body,HtmlBody.isNotHtml,to);
        }

        public static bool sendEmail(string subject, string body, HtmlBody isHtml, List<string> to)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient googleSmpt = new SmtpClient();


                mail.From = new MailAddress(KeyBLL.selectKey("MainEmail").value);

                foreach (var email in to)
                {
                    mail.To.Add(new MailAddress(email));
                }
                
                mail.Subject = subject;
                mail.Body = body;

                switch (isHtml)
                {
                    case HtmlBody.isHtml:
                        mail.IsBodyHtml = true;
                        break;
                    case HtmlBody.isNotHtml:
                        mail.IsBodyHtml = false;
                        break;
                    default:
                        break;
                }

                googleSmpt.Host = KeyBLL.selectKey("Hostemail").value;
                googleSmpt.Port = 587;
                googleSmpt.Credentials = new NetworkCredential(KeyBLL.selectKey("MainEmail").value, KeyBLL.selectKey("MainEmailPassword").value);
                googleSmpt.EnableSsl = true;
                googleSmpt.Send(mail);

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
