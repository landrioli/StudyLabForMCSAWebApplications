using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._4___ChapterFour
{
    class CollectionsExercises : IExerciseContent
    {
        public void Execute()
        {
            People people = new People(3);
            people.Add(new Person { Name = "Ali", Age = 22 });
            people.Add(new Person { Name = "Sundus", Age = 21 });
            people.Add(new Person { Name = "Hogi", Age = 12 });
            foreach (var item in people)
            {
                //Cast from object to Person
                Person person = (Person)item;
                Console.WriteLine("Name:{0} Age:{1}", person.Name, person.Age);
            }
        }

        class People : IEnumerable
        {
            Person[] people;
            int index = -1;
            public void Add(Person per)
            {
                if (++index < people.Length)
                {
                    people[index] = per;
                }
            }
            public People(int size)
            {
                people = new Person[size];
            }
            public IEnumerator GetEnumerator()
            {
                return new PersonEnum(people);
            }
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        //Implement IEnumerator
        class PersonEnum : IEnumerator
        {
            Person[] _people;
            int index = -1;
            public PersonEnum(Person[] people)
            {
                _people = people;
            }
            //Check whether foreach can move to next iteration or not
            public bool MoveNext()
            {
                //Return 1 jumps 1 ..
                this.index = this.index + 2;
                return (++index < _people.Length);

                //Return the normal order 1 by 1
                //return (++index < _people.Length);
            }
            //Reset the iteration
            public void Reset()
            {
                index = -1;
            }
            //Get current value
            public object Current
            {
                get
                {
                    return _people[index];
                }
            }
        }


    }
}
