using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._12___ChapterTwelve
{
    class ReflectionExercises : IExerciseContent
    {
        public void Execute()
        {
            //******Retrieve Property Values**********//
            //Get types
            Type vtype = typeof(VehicleApp);
            Type atype = typeof(DeveloperAttribute);
            //get the developerattribute attached with vehivle type
            DeveloperAttribute developer =
                (DeveloperAttribute)Attribute.GetCustomAttribute(vtype, atype);
            Console.WriteLine(developer.Age);
            Console.WriteLine(developer.Name);
        }

        class DeveloperAttribute : Attribute
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        [Developer(Name = "Leandro Andrioli", Age = 22)]
        class VehicleApp
        {
            public int Wheels { get; set; }
            public string Color { get; set; }
        }
    }
}
