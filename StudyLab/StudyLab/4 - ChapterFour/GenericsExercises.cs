using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._4___ChapterFour
{
    class GenericsExercises : IExerciseContent
    {
        public void Execute()
        {
            ////Here 'T' and 'U' types are same
            //GenericClass<Person, Person> genPP =
            //    new GenericClass<Person, Person>();
            ////Here 'T' inherit 'U' type
            //GenericClass<Student, Person> genSP =
            //    new GenericClass<Student, Person>();

            var ex = new ExampleGenericMethods();
            //Call generic method which has single generic type
            ex.GenericMethodArgs<int>(10);
            int FromSingle = ex.ReturnFromGenericMethodArgs<int>(10);
            Console.WriteLine(FromSingle + "\n");
            //Call generic method which has multiple generic type
            ex.MultipleGenericMethodArgs<string, int>("Exam", 70483);
            int FromMultiple =
                ex.ReturnFromMultipleGenericMethodArgs<string, int>("Exam: ");
            Console.WriteLine(FromMultiple);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public Person()
        {
            this.Name = "default";
        }
    }
    class Student : Person
    {
        //TODO:
    }
    class GenericClass<T> where T : Person, new()
    {
        //Where T can only be Person which has a default constructor
        //TODO:
    }

    class GenericClass<T, U> where T : U
    {
        //TODO
    }

    class ExampleGenericMethods
    {
        public void GenericMethodArgs<T>(T first)
        {
            Console.WriteLine(first);
        }
        public T ReturnFromGenericMethodArgs<T>(T first)
        {
            return first;
        }
        public void MultipleGenericMethodArgs<T, U>(T first, U second)
        {
            Console.WriteLine("{0}: {1}", first, second);
        }
        public U ReturnFromMultipleGenericMethodArgs<T, U>(T first)
        {
            U temp = default(U);
            return temp;
        }
    }
}
