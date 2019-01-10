using StudyLab.ChapterOne;
using StudyLab.ChapterThree;
using StudyLab.ChapterTwo;
using StudyLab._3___ChapterThree.ChallengeOne;

namespace StudyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            IExerciseContent exercise = new ChapterThreeChallengeOne();
            exercise.Execute();
        }
    }
}
