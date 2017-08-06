using AssistanceOnlineDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistanceOnlineBLL
{
    public static class KeyBLL
    {
        /// <summary>
        /// Obtiene un objeto Key de la base de datos
        /// </summary>
        /// <param name="description">descripción del key</param>
        /// <returns></returns>
        public static Key selectKey(string description)
        {
            using (AssistanceOnlineContext context = new AssistanceOnlineContext())
            {
                return context.Key.Where(c => c.description == description && c.active == true).FirstOrDefault();
            }
        }
    }
}
