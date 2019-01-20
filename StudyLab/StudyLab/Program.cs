using StudyLab.ChapterOne;
using StudyLab.ChapterThree;
using StudyLab.ChapterTwo;
using StudyLab._3___ChapterThree.ChallengeOne;
using StudyLab._4___ChapterFour;
using StudyLab._5___ChapterFive;
using StudyLab._5___ChapterFive.ChallengeOne;

namespace StudyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            IExerciseContent exercise = new ChapterFiveChallengeOne();
            exercise.Execute();
        }
    }
}
