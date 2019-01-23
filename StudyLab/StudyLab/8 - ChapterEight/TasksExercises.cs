using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StudyLab._8___ChapterEight
{
    class TasksExercises : IExerciseContent
    {
        public void Execute()
        {
            //ExecuteTaskWithReturnValue();
            //WaitAllTasks();
            //ContinueTask();
            //ApplyNestedTask();
            ApplyCancelationToken();
        }

        private void ExecuteTaskWithReturnValue()
        {
            Task<int> task = new Task<int>(() =>
            {
                Console.WriteLine("Hello Leandro, I'm running");
                return 5;
            });

            task.Start(); //start myTask
            Console.WriteLine("Hello from Main Thread");
            Thread.Sleep(5000);
            //Wait the main thread until myTask is finished
            //and returns the value from myTask operation (myMethod)
            int i = task.Result;

            Console.WriteLine("myTask has a return value = {0}", i);
            Console.WriteLine("Bye From Main Thread");
        }

        private void WaitAllTasks()
        {
            Task tsk1 = Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("tsk1 completed");
            });
            Task tsk2 = Task.Run(() =>
            {
                Thread.Sleep(5500);
                Console.WriteLine("tsk2 completed");
            });
            Task tsk3 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("tsk3 completed");
            });
            //Store reference of all tasks in an array of Task
            Task[] allTasks = { tsk1, tsk2, tsk3 };
            //Wait for all tasks to complete
            Task.WaitAll(allTasks);
        }

        private void ContinueTask()
        {
            Task tsk1 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("tsk1");
                throw new Exception();
            });
            //Run tsk2 as soon tsk1 get completed (including if tsk1 throw an exception)
            Task tsk2 = tsk1.ContinueWith((t) =>
            {
                Thread.Sleep(500);
                Console.WriteLine("tsk2");
            });
            Task tsk3 = tsk2.ContinueWith((t) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("tsk3");
            });
            tsk3.Wait();
        }

        private void ApplyNestedTask()
        {
            Task outer = Task.Run(() =>
            {
                Console.WriteLine("Hi I'm outer task ");
                Task inner = Task.Run(() =>
                {
                    Console.WriteLine("Hi I'm inner task");
                    Thread.Sleep(2000);
                    Console.WriteLine("By from inner task");
                });
            });
            Thread.Sleep(500);
            Console.WriteLine("By from outer task");
            outer.Wait();
        }

        private void ApplyCancelationToken()
        {
            //1 - Instantiate a cancellation token source
            CancellationTokenSource source = new CancellationTokenSource();
            //2 - Get token from CancellationTokenSource.Token property
            CancellationToken token = source.Token;
            //3 - Pass token to Task
            Task tsk = Task.Run(() =>
            {
                Console.WriteLine("Hello from tsk");
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("*");
                    if (token.IsCancellationRequested == true)
                    {
                        Console.WriteLine("Bye from tsk");
                        return;
                    }
                }
            }, token);
            Console.WriteLine("Hello from main thread");
            //Wait
            Thread.Sleep(4000);
            //4 - notify for cancellation
            source.Cancel(); //IsCancellationRequested = true;
            Console.WriteLine("Token canceled");
            //Wait
            Thread.Sleep(3000);
            Console.WriteLine("Bye from main thread");
        }
    }
}
