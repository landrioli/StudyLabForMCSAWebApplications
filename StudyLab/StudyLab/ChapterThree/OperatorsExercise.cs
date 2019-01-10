using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab.ChapterThree
{
    class OperatorsExercise : IExerciseContent
    {
        public void Execute()
        {
            Distance d1 = new Distance { meter = 10 };
            Distance d2 = new Distance { meter = 20 };

            if (d1 < d2)
            {
                Console.WriteLine("d1 is less than d2");
            }
            else if (d2 < d1)
            {
                Console.WriteLine("d2 is less than d1");
            }

            DistanceTwo d3 = new DistanceTwo { centimeter = 10 };
            DistanceTwo d4 = new DistanceTwo { centimeter = 20 };
            if (d3 < d4)
            {
                Console.WriteLine("d3 is less than d4");
            }
            else if (d4 < d3)
            {
                Console.WriteLine("d4 is less than d3");
            }

        }
    }

    class Distance
    {
        public int meter { get; set; }
        public static bool operator <(Distance d1, Distance d2)
        {
            return (d1.meter < d2.meter);
        }
        public static bool operator >(Distance d1, Distance d2)
        {
            return (d1.meter > d2.meter);
        }
    }

    class DistanceTwo
    {
        public int centimeter { get; set; }
        public static bool operator <(DistanceTwo d1, DistanceTwo d2)
        {
            return (d1.centimeter < d2.centimeter);
        }
        public static bool operator >(DistanceTwo d1, DistanceTwo d2)
        {
            return (d1.centimeter > d2.centimeter);
        }
    }

    class DistanceThree
    {
        public int millimeter { get; set; }
    }
    
    // This will generate a compiler error: The operator overloading needs to be created inside the class that it represents
    //class CustomOperatorsManager
    //{
    //    public static bool operator <(DistanceThree d1, DistanceThree d2)
    //    {
    //        return (d1.millimeter < d2.millimeter);
    //    }
    //    public static bool operator >(DistanceThree d1, DistanceThree d2)
    //    {
    //        return (d1.millimeter > d2.millimeter);
    //    }
    //}
}
