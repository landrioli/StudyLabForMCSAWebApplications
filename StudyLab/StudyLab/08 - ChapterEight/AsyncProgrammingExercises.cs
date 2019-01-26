using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyLab._8___ChapterEight
{
    class AsyncProgrammingExercises : IExerciseContent
    {
        public void Execute()
        {
            button1_Click(null, EventArgs.Empty);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello World");
            int data = await DoComplicatedTaskWithReturnAsync();
            Console.WriteLine("Bye World");
        }
        private Task<int> DoComplicatedTaskWithReturnAsync()
        {
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                return 15;
            });
            return task;
        }

        private Task DoComplicatedTaskAsync()
        {
            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Counting");
                }
            });
            return task;
        }
    }
}
