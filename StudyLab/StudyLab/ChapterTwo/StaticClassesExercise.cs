using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab.ChapterTwo
{
    public class StaticClassesExercise : IExerciseContent
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    static class Helper
    {
        public static int Age;
        static Helper()
        {
            Age = 22;
        }

        //Do not allow public constructor, so the private one is only used to initialize the internal static members 
        //public static Helper()
        //{
        //    Age = 22;
        //}
    }
}
