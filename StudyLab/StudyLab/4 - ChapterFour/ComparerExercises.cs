using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._4___ChapterFour
{
    class ComparerExercises : IExerciseContent
    {
        public void Execute()
        {
            ArrayList dogs = new ArrayList();
            dogs.Add(new Dog { Name = "Sundus", Age = 21 });
            dogs.Add(new Dog { Name = "Ali", Age = 22 });
            dogs.Add(new Dog { Name = "Hogi", Age = 12 });
            //sort list according to age
            dogs.Sort(new SortAge());
            foreach (Dog Dog in dogs)
            {
                Console.WriteLine(Dog.Age + " " + Dog.Name);
            }
            //sort list according to name
            dogs.Sort(new SortName());
            foreach (Dog Dog in dogs)
            {
                Console.WriteLine(Dog.Name + " " + Dog.Age);
            }
        }
    }

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class SortAge : IComparer
    {
        public int Compare(object x, object y)
        {
            Dog first = (Dog)x;
            Dog second = (Dog)y;
            return first.Age.CompareTo(second.Age);
        }
    }
    class SortName : IComparer
    {
        public int Compare(object x, object y)
        {
            Dog first = (Dog)x;
            Dog second = (Dog)y;
            return String.Compare(first.Name, second.Name, StringComparison.Ordinal);
        }
    }
}