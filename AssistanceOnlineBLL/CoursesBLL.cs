using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssistanceOnlineDAL;

namespace AssistanceOnlineBLL
{
    public static class CoursesBLL
    {
        public static List<Courses> findCoursesbyUser(int idUser)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    return context.Courses.Where(c => c.idUser == idUser).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void createCourse(Courses course)
        {
            try
            {
                using (var context = new AssistanceOnlineContext())
                {
                    course.active = true;
                    course.modificationDate = DateTime.UtcNow;
                    course.creationDate = DateTime.UtcNow;
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
