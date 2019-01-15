using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaTracker.Persistance
{
    public static class ServiceLocator
    {
        public static IStudentService GetStudentService(string type)
        {
            switch (type)
            {
                case "Development":
                    return new DevelopmentStudentService();
                case "Production":
                    return new StudentFileService(Environment.CurrentDirectory + "/students.txt");
                default:
                    return new DevelopmentStudentService();
            }
        }
    }
}
