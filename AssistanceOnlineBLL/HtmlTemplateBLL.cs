using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistanceOnlineDAL;

namespace AssistanceOnlineBLL
{
    public static class HtmlTemplateBLL
    {
        public static HtmlTemplate getHtmlTemplate(int idHtmlTemplate)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    return context.HtmlTemplate.Where(c => c.idHtmlTemplate == idHtmlTemplate).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                return new HtmlTemplate();
            }
        }
    }
}
