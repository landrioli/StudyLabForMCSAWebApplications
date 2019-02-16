using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._04___ChapterFour
{
    public class StringExercises : IExerciseContent
    {
        public void Execute()
        {
            StringFormatDateAndTime();
        }

        public void FormatStringAccordingToCulture()
        {
            DateTime d = new DateTime(2013, 4, 22);
            CultureInfo provider = new CultureInfo("en-US");
            Console.WriteLine(d.ToString("d", provider)); // Displays 4/22/2013
            Console.WriteLine(d.ToString("D", provider)); // Displays Monday, April 22, 2013
            Console.WriteLine(d.ToString("M", provider)); // Displays April 22

            d = new DateTime(2013, 4, 22);
            provider = new CultureInfo("pt-BR");
            Console.WriteLine(d.ToString("d", provider)); // Displays 22/04/2013
            Console.WriteLine(d.ToString("D", provider)); // Displays segunda - feira, 22 de abril de 2013
            Console.WriteLine(d.ToString("M", provider)); // Displays 22 de abril
        }


        public void StringFormatDateAndTime()
        {
            //✑ The time must be formatted as hour:minute AM/ PM, for example 2:00 PM.
            //    ✑ The date must be formatted as month / day / year, for example 04 / 21 / 2013.
            //    ✑ The temperature must be formatted to have two decimal places, for example 23.45.
     
                 DateTime date = new DateTime(2019, 02, 16);
            double temp = 15;
            CultureInfo provider = new CultureInfo("en-US");
            string output = string.Format(provider, "Temperature at {0:hh:mm tt} {0:MM/dd/yyyy} on {1:N2}", date, temp);
            Console.WriteLine(output); //Temperature at 12:00 AM 02/16/2019 on 15.00

            output = string.Format(provider, "Temperature at {0:hh:mm tt} {0:MM/dd/yyyy} on {1:N3}", date, temp);
            Console.WriteLine(output); //Temperature at 12:00 AM 02 / 16 / 2019 on 15.000
        }
    }
}
