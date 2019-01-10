using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab.ChapterTwo
{
    public class StructExercise : IExerciseContent
    {
        public void Execute()
        {
            TestStruct t = new TestStruct(10, 5);

            //Console.WriteLine("Sum of {0} + {1} = {2}.", t.A, t.B, t.Sum());
            Console.WriteLine("Sum of {0} + {1} = {2}.", 10, 5, t.Sum());

            Console.ReadLine();
        }
    }

    public struct TestStruct
    {
        private readonly int A;
        private readonly int B;

        public TestStruct(int a, int b)
        {
            A = a;
            B = b;
        }
        public int Sum()
        {
            return A + B;
        }
    }
}
