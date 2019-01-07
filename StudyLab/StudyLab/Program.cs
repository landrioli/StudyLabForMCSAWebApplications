using StudyLab.ChapterOne;

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
