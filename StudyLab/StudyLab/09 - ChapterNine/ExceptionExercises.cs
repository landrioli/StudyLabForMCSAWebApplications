using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._09___ChapterNine
{
    class ExceptionExercises : IExerciseContent
    {
        public void Execute()
        {
            try
            {
                MethodWillThrowExThree();
            }
            catch (MyCustomException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void MethodWillThrowEx()
        {
            throw  new MyCustomException();
        }

        private void MethodWillThrowExTwo()
        {
            throw new MyCustomException("Foo");
        }

        private void MethodWillThrowExThree()
        {
            throw new MyCustomException("Foo", new StackOverflowException());
        }
    }

    public class MyCustomException : Exception
    {
        public MyCustomException()
        {
        }

        public MyCustomException(string message) : base(message)
        {
        }

        public MyCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
