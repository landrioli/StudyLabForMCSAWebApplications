using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._4___ChapterFour
{
    class ComparableExercises :  IExerciseContent
    {
        public void Execute()
        {
            ArrayList coffe = new ArrayList();
            coffe.Add(new Coffe { Name = "A", Price = 2 });
            coffe.Add(new Coffe { Name = "B", Price = 3 });
            coffe.Add(new Coffe { Name = "C", Price = 4 });
            //sort list of coffes
            coffe.Sort();

            foreach (Coffe obj in coffe)
            {
                Console.WriteLine(obj.Price + " " + obj.Name);
            }
        }
    }

    class Coffe : IComparable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompareTo(object obj)
        {
            Coffe next = (Coffe)obj;
            return this.Price.CompareTo(next.Price);
        }
    }
}
