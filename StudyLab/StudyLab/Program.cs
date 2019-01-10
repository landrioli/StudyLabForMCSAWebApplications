using StudyLab.ChapterOne;
using StudyLab.ChapterThree;
using StudyLab.ChapterTwo;

namespace StudyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            IExerciseContent exercise = new OperatorsExercise();
            exercise.Execute();
        }
    }
}
