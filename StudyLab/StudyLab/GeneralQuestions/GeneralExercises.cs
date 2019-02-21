#define RELEASE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using StudyLab;

namespace StudyLab.GeneralQuestions
{
    public class GeneralExercises : IExerciseContent
    {
        public void Execute()
        {
            HashSha1();
            var obj = new TestClass();
            obj.Exec();
        }

        public void HashSha1()
        {
            var ue = new UnicodeEncoding();
            var secretBytes = ue.GetBytes("Secret Message");
            SHA1Managed obj = new SHA1Managed();
            var secretHashed = obj.ComputeHash(secretBytes);
        }
    }

        public class TestClass
        {
            [Conditional("RELEASE")]
            public void Exec()
            {
                Console.WriteLine("RELEASE");
                ExecTwo();
            }

            private void ExecTwo()
            {
    #if (DEBUG)
                Console.WriteLine("ExecTwo");
    #endif
            }

       
        }
}
