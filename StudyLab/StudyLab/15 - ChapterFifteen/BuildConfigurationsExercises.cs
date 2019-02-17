using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyLab._15___ChapterFifteen
{
    public class BuildConfigurationsExercises : IExerciseContent
    {
        public void Execute()
        {
            Timer t = new Timer(TimerCallback, null, 0, 2000);
            Console.ReadLine();
        }
        private static void TimerCallback(Object o)
        {
            Console.WriteLine($"In TimerCallback:{DateTime.Now}");
            GC.Collect();
        }
    }
}
