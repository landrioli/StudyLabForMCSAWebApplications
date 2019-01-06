using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyLab.Chapter1;

namespace StudyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            IExerciseContent exercise = new ChapterOneChallengeTwo();
            exercise.Execute();
        }
    }
}
