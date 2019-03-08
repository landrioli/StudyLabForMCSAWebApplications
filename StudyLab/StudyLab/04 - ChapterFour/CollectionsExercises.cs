using System;
using System.Collections;
using System.Collections.Concurrent;
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
            //People people = new People(3);
            //people.Add(new Person { Name = "Ali", Age = 22 });
            //people.Add(new Person { Name = "Sundus", Age = 21 });
            //people.Add(new Person { Name = "Hogi", Age = 12 });
            //foreach (var item in people)
            //{
            //    //Cast from object to Person
            //    Person person = (Person)item;
            //    Console.WriteLine("Name:{0} Age:{1}", person.Name, person.Age);
            //}
            //ConcurentDictionary();
            // StringCustomFormats();
            Cast(new People(3));
            Cast(new { sad = 2 });

        }

        public void Cast(object obj)
        {
            var res = (People)obj;
            var dado = res.Age;
        }

        public void StringCustomFormats()
        {
            int num = 5;
            string result = num.ToString();
            result = num.ToString("####0");
            result = num.ToString("#");
            num = 54321;
            result = num.ToString();
            result = num.ToString("0####0");
            result = num.ToString("#");
            result = num.ToString("#####.#");
        }

        public void ConcurentDictionary()
        {
            int temp = 12;
            Console.WriteLine(temp.ToString("D"));
            //D3 = 3 digits will be display (012)
            Console.WriteLine(temp.ToString("D3"));

            // Construct a ConcurrentDictionary
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>();
            ConcurrentDictionary<int, int> cdTwo = new ConcurrentDictionary<int, int>();
            // Bombard the ConcurrentDictionary with 10000 competing AddOrUpdates
            Parallel.For(0, 10000, i =>
            {
                // Initial call will set cd[1] = 1.  
                // Ensuing calls will set cd[1] = cd[1] + 1
                cd.AddOrUpdate(1, 1, (key, oldValue) => oldValue + 1);
            });

            Console.WriteLine("After 10000 AddOrUpdates, cd[1] = {0}, should be 10000", cd[1]);


            Parallel.For(0, 10000, i =>
            {
                // Initial call will set cd[1] = 1.  
                // Ensuing calls will set cd[1] = cd[1] + 1
                cdTwo.AddOrUpdate(3, 2, (key, oldValue) => oldValue + 1);
            });

            // Should return 100, as key 2 is not yet in the dictionary
            int value = cd.GetOrAdd(2, (key) => 100);
            Console.WriteLine("After initial GetOrAdd, cd[2] = {0} (should be 100)", value);

            value = cd.GetOrAdd(2, 10000);
            Console.WriteLine("After second GetOrAdd, cd[2] = {0} (should be 100)", value);
        }


        class People : Person, IEnumerable
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
