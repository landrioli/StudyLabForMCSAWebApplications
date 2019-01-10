using StudyLab.ChapterOne;
using StudyLab.ChapterTwo;

namespace StudyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            IExerciseContent exercise = new StructExercise();
            exercise.Execute();
        }
    }
}
