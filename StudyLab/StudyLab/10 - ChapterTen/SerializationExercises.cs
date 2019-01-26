﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StudyLab._10___ChapterTen
{
    class SerializationExercises : IExerciseContent
    {
        public void Execute()
        {
            //BinarySerialization();
            DataContractSerialization();
        }

        private static void BinarySerialization()
        {
            //Created the Instance and initialized
            Teacher teacher = new Teacher()
            {
                ID = 1,
                Name = "Ijaz",
                Salary = 1000
            };

            //Binary Serializer
            BinaryFormatter formatter = new BinaryFormatter();
            //Sample.bin(Binary File is Created) to store binary serialized data
            using (FileStream file = new FileStream("Sample.bin", FileMode.Create))
            {
                //this function serialize the "teacher" (Object) into "file" (File)
                formatter.Serialize(file, teacher);
            }
            Console.WriteLine("Leandro the Binary Serialization is Successfully Done!");
            //Binary Deserialization
            using (FileStream file = new FileStream("Sample.bin", FileMode.Open))
            {
                Teacher dteacher = (Teacher)formatter.Deserialize(file);
                Console.WriteLine($"Leandro the Deserialization: ID: {dteacher.ID}, Name:{dteacher.Name}, Salary:{dteacher.Salary}!");
            }
        }

        private static void DataContractSerialization()
        {
            var teacher = new TeacherDataContract() { name = "Maria", salary = 150 };

            //Serialization
            DataContractSerializer dataContract = new DataContractSerializer(typeof(TeacherDataContract));
            using (var stream = new FileStream("Sample.xml", FileMode.Create))
            {
                dataContract.WriteObject(stream, teacher);
            }
            Console.WriteLine("Data has been Serialized!");
            //Deserialization
            dataContract = new DataContractSerializer(typeof(TeacherDataContract));
            using (var stream = new FileStream("Sample.xml", FileMode.Open))
            {
                teacher = (TeacherDataContract)dataContract.ReadObject(stream);
            }
            Console.WriteLine("Data has been Deserialized!");
        }
    }

    [DataContract]
    public class TeacherDataContract
    {
        [DataMember]
        private int id = 1;
        [DataMember]
        public string name { get; set; }
        [IgnoreDataMember]
        public long salary { get; set; }
    }

    [Serializable]
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [NonSerialized]
        public decimal Salary;
    }
}