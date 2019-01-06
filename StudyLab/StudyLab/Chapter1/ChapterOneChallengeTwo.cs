using System;
using System.Text;

/*
 Challenge 2: Develop a Student Report Card Application
Develop a report card application that saves students’ marks information; show position and report card of
each student in descending order.
Requirements
• Each student has three subjects (English, Math and Computer).
• Application will save each student’s marks along with student’s name.
• Application will calculate total marks.
• Application will show position and report card in descending order.
*/

namespace StudyLab.Chapter1
{
    public class ChapterOneChallengeTwo : IExerciseContent
    {
        private readonly string[] _reportFields = { "Student Name", "English Marks", "Math Marks", "Computer Marks" };
        private string[,] _studentReportCard;

        public ChapterOneChallengeTwo()
        {
            
        }

        public void Execute()
        {
            CaptureInputStudentData();
            DisplayStudentDataReport();
        }

        private void DisplayStudentDataReport()
        {
            StringBuilder message = new StringBuilder();
            Console.WriteLine("****************Report Card * ******************");
            for (int i = 0; i < _studentReportCard.GetLength(0); i++)
            {
                for (int j = 0; j < _studentReportCard.GetLength(1); j++)
                {
                    message.Append(_studentReportCard[i, j] + " | ");
                }
                Console.WriteLine(message);
                message.Clear();
            }
            Console.WriteLine("************************************************");
        }

        public void CaptureInputStudentData()
        {
            Console.WriteLine("Enter Total Students:");
            var totalStudents = int.Parse(Console.ReadLine());
            _studentReportCard = new string[totalStudents, _reportFields.Length];

            for (int i = 0; i < totalStudents; i++)
            {
                for (int j = 0; j < _reportFields.Length; j++)
                {
                    Console.WriteLine($"Enter {_reportFields[j]}:");
                    var value = Console.ReadLine();
                    _studentReportCard[i, j] = value;
                }
            }
        }
    }
}
