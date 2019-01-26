using System;
using StudyLab.ChapterOne;
using StudyLab.ChapterThree;
using StudyLab.ChapterTwo;
using StudyLab._10___ChapterTen;
using StudyLab._3___ChapterThree.ChallengeOne;
using StudyLab._4___ChapterFour;
using StudyLab._5___ChapterFive;
using StudyLab._5___ChapterFive.ChallengeOne;
using StudyLab._8___ChapterEight;

namespace StudyLab
{
    class Program
    {
        static void Main(string[] args)
        {
            IExerciseContent exercise = new SerializationExercises();
            exercise.Execute();
            Console.ReadLine();
        }
    }
}
