using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._5___ChapterFive
{
    class DelegateAndEventsExercises : IExerciseContent
    {
        public delegate void DelegateName(string msg);

        public void Execute()
        {
            //RegisterAndCallDelegates();
            //RegisterAndCallMulticastDelegates();

            CallTestBuildinDelegates();
        }

        private void CallTestBuildinDelegates()
        {
            var instance = new TestBuildinDelegates();
            instance.CallFunc();
        }

        private void RegisterAndCallMulticastDelegates()
        {
            string msg = "Leandro";
            //Create delegate
            DelegateName del = DisplayOne;
            //Multicast delegate
            del += DisplayTwo;
            //calling delegate
            del(msg);

            foreach (DelegateName item in del.GetInvocationList())
            {
                //invoke each method, and display return value
                item(msg);
            }

            //remove method's reference
            del -= DisplayOne;
            del(msg);

        }

        static void DisplayOne(string msg)
        {
            Console.WriteLine($"Display One {msg}");
        }

        static void DisplayTwo(string msg)
        {
            Console.WriteLine($"Display Two {msg}");
        }

        private static void RegisterAndCallDelegates()
        {
            string message = "Leandro Andrioli";
            // Create an instance of the delegate
            DelegateName del = new DelegateName(DisplayOne);
            //Calling the delegate
            del(message);

            // Another way if declaration
            DelegateName delTwo = DisplayTwo;
            delTwo.Invoke(message);
        }

        // Declare a method with the same signature as the delegate.

    }

    class TestBuildinDelegates
    {
        static int Add(int x, int y)
        {
            Console.Write("{0} + {1} = ", x, y);
            return (x + y);
        }

        static int Min(int x, int y)
        {
            Console.Write("{0} - {1} = ", x, y);
            return (x - y);
        }

        static int Mul(int x, int y)
        {
            Console.Write("{0} * {1} = ", x, y);
            return (x * y);
        }

        static string Name()
        {
            Console.Write("My name is = ");
            return "Leandro";
        }

        static string DynamicName(string name)
        {
            Console.Write("My name is = ");
            return name;
        }

        public void CallFunc()
        {
            //return string value
            Func<string> info = Name;
            Console.WriteLine(info());
            //return string, and take string as parameter
            Func<string, string> dynamicInfo = DynamicName;
            Console.WriteLine(dynamicInfo("Leandro"));
            //return int, and take two int as parameter
            Func<int, int, int> calculate = Add;
            calculate += Min;
            calculate += Mul;
            foreach (Func<int, int, int> item in calculate.GetInvocationList())
            {
                Console.WriteLine(item(10, 5));
            }
        }
    }

    class Parent
    {
    }

    class Child : Parent
    {
    }

    delegate Parent CovarianceHandle();

    class Program
    {
        static Child CovarianceMethod()
        {
            Console.WriteLine("Covariance Method");
            return new Child();
        }

        static void Run(string[] args)
        {
            CovarianceHandle del = CovarianceMethod;
            del();
        }
    }


    class Room
    {
        public event EventHandler Alert;
        private int _Temperature;
        public int Temperature
        {
            get { return this.Temperature; }
            set
            {
                this.Temperature = value;
                if (this.Temperature > 60)
                {
                    if (Alert != null)
                    {
                        Alert(this, EventArgs.Empty);
                    }
                }
            }
        }
    }
    class Test
    {
        static void Method(string[] args)
        {
            Room room = new Room();
            room.Alert += OnAlert;
            room.Temperature = 75;
        }
        private static void OnAlert(object sender, EventArgs e)
        {
            Room room = (Room)sender;
            Console.WriteLine("Shutting down, Room temp = {0}", room.Temperature);
        }
    }
    //Output Shutting down, Room temp = 75
}