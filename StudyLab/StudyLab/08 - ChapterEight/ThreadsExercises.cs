using System;
using System.Threading;

namespace StudyLab._8___ChapterEight
{
    class ThreadsExercises : IExerciseContent
    {
        static bool stop = false;

        public void Execute()
        {
            //CreateSimpleThread();
            //CreateForegroundThread();
            //CreateThreadByPriority();
            //CreateThreadPool();
            ThreadLocal();
        }

        private void ThreadLocal()
        {
            ThreadLocal<int> _field =
                new ThreadLocal<int>(() =>
                {
                    return Thread.CurrentThread.ManagedThreadId;
                });

            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();

            new Thread(() =>
                    {
                        for (int x = 0; x < _field.Value; x++)
                        {
                            Console.WriteLine("Thread B: {0}", x);
                        }
                    }).Start();
        }

        private void CreateThreadPool()
        {
            // Queue the thread.
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            Console.WriteLine("Hello From Main Thread.");
            // The thread pool uses background threads, its important to keep main thread busy otherwise 
            // program will terminate before the background thread complete its execution
            Console.ReadLine(); //Wait for Enter
            Console.WriteLine("Hello Again from Main Thread.");
            // Queue the thread with Lambda
            ThreadPool.QueueUserWorkItem((s) =>
            {
            //s = state
            //no value is assign to s
            //so s is null
            Console.WriteLine("Hi I'm another free thread from thread pool");
            });
            Console.ReadLine(); //Wait for Enter
        }

        private void CreateThreadByPriority()
        {
            Thread thread1 = new Thread(new ThreadStart(MyMethodForPriority));
            thread1.Name = "Thread 1";
            thread1.Priority = ThreadPriority.Lowest;
            Thread thread2 = new Thread(new ThreadStart(MyMethodForPriority));
            thread2.Name = "Thread 2";
            thread2.Priority = ThreadPriority.Highest;
            Thread thread3 = new Thread(new ThreadStart(MyMethodForPriority));
            thread3.Name = "Thread 3";
            thread3.Priority = ThreadPriority.Normal;
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Thread.Sleep(10000);
            stop = true;
        }

        private void CreateForegroundThread()
        {
            //Instantiate a thread
            Thread myThread = new Thread(new ThreadStart(MyThreadMethod));
            //by default Isbackgrount value is always false
            //now the thread become a background thread:
            myThread.IsBackground = true;
            //Start the execution of thread
            myThread.Start();
            //Everything else is part of Main Thread.
            Console.WriteLine("Hello From Main Thread");
        }

        private void CreateSimpleThread()
        {
            //Instantiate a thread
            Thread myThread = new Thread(new ThreadStart(MyThreadMethod));
            //Start the execution of thread
            myThread.Start();
            //It's the part of Main Method
            Console.WriteLine("Hello From Main Thread");
        }

        private static void ThreadProc(Object stateInfo)
        {
            // No state object was passed to QueueUserWorkItem, so
            // stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }

        private static void MyMethodForPriority()
        {
            //Get Name of Current Thread
            string threadName = Thread.CurrentThread.Name.ToString();
            //Get Priority of Current Thread
            string threadPriority = Thread.CurrentThread.Priority.ToString();
            long count = 0;
            while (stop != true)
            {
                count++;
            }
            Console.WriteLine("{0,-11} with {1,11} priority " +
                              "has a count = {2,13}", Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(),
                count);
        }

        private static void MyThreadMethod()
        {
            Console.WriteLine("Hello From My Custom Thread");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("Bye From My Custom Thread");
        }
    }
}
