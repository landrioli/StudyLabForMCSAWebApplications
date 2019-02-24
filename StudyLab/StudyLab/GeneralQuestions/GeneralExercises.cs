#define RELEASE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using StudyLab;

namespace StudyLab.GeneralQuestions
{
    public class GeneralExercises : IExerciseContent
    {
        public void Execute()
        {
            Hash();
            //var obj = new TestClass();
            //obj.Exec();
            //DownloadImage();
            //TestingRegex();
        }

        public void TestingRegex()
        {
            string pattern = @"\b\w+es\b";
            Regex rgx = new Regex(pattern);
            string sentence = "Who writes these notes?";
            var result = rgx.Matches(sentence);
            foreach (Match match in result)
                Console.WriteLine("Found '{0}' at position {1}",
                    match.Value, match.Index);

            foreach (Match match in result)
            {
                if(match.Success)
                    Console.WriteLine("Found '{0}' at position {1}",
                        match.Value, match.Index);
            }
            var firstMatch = Regex.Match(sentence, pattern);;
            var isValid = Regex.IsMatch(sentence, pattern);
        }

        public void Hash()
        {
            var ue = new UnicodeEncoding();
            var secretBytes = ue.GetBytes("Secret Message");
            SHA1Managed obj = new SHA1Managed();
            var secretHashed = obj.ComputeHash(secretBytes);


            var hasher = HashAlgorithm.Create();
            var byteArray = Encoding.UTF8.GetBytes("MY SECRET VALUE LA");
            var result = hasher.ComputeHash(byteArray);
            Console.WriteLine(result);
            Console.WriteLine(hasher.Hash);
            
        }
        

        public void GetTypes()
        {
            List<Type> types =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(t => t.GetTypes())
                    .Where(t => t.IsClass && t.Assembly == this.GetType().Assembly).ToList();

            var types2 =
                AppDomain.CurrentDomain.GetAssemblies()
                    .Select(t => t.GetTypes()).Where(t => t[2].IsClass);

        }

        public void DownloadImage()
        {
            var url = @"https://cdn.houseplans.com/product/q5qkhirat4bcjrr4rpg9fk3q94/w1024.jpg?v=8";
            var client = new WebClient();
            client.DownloadFile(url, @"C:\Temp\file1.jpg");
            client.Dispose();

            // This method will not work 
            var clientTwo = new WebClient();
            var writer = new StreamWriter(@"C:\Temp\file2.jpg");
            writer.Write(client.DownloadData(url));
            writer.Dispose();
            client.Dispose();
        }
    }
    [System.FlagsAttribute()]
    public enum TestEnum
    {
        one = 1,
        two = 2
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

    public class Factory<T> where T : new()
    {
        public T CreateObj<T>() where T : new()
        {
            T obj = new T();
            return obj;
        }
    }
}
