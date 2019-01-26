using System;
using System.Collections.Generic;

//Challenge 1: Develop a Transformer
    //We all have watched the Transformers film.They’re intelligent vehicles which can transform into jets,
    //cars and boats.Your job is to make an application where a transformer could change its behavior into the
    //following vehicles.
    //Vehicle Condition to transform Attributes
    //Jet When transformer is on air Wheels = 8
    //Max Speed = 900
    //Car When transformer is on road Wheels = 4
    //Max Speed = 350
    //Boat When transformer is on water Wheels = 0
    //Max Speed = 200
    //Your job is to implement a Run method for each vehicle that transformer runs whenever the landscape
    //changes.
    //Tip
    //1. Use Enum to store landscape, i.e., air, road, water.
    //2. Follow OOP principle of Polymorphism.

namespace StudyLab._3___ChapterThree.ChallengeOne
{
    class ChapterThreeChallengeOne: IExerciseContent
    {
        public void Execute()
        {
            TransformerFactory.CreateInstance(LandScape.Air).Run();

            TransformerFactory.CreateInstance(LandScape.Road).Run();

            TransformerFactory.CreateInstance(LandScape.Water).Run();
        }
    }

    public enum LandScape : byte
    {
        Air = 1,
        Road = 2,
        Water = 3
    }

    public abstract class Transformer
    {
        public abstract int Wheels { get; }
        public abstract int MaxSpeed { get; }

        public abstract void Run();
    }

    public class Jet : Transformer
    {
        private const string TransformerName = "Jet";

        public override int Wheels
        {
            get { return 8; }
        }
        public override int MaxSpeed
        {
            get { return 900; }
        }

        public override void Run()
        {
            Console.WriteLine($"I am {TransformerName} - My Wells is {Wheels} and MaxSpeed is {MaxSpeed}.");
        }
    }

    public class Car : Transformer
    {
        private const string TransformerName = "CAR";

        public override int Wheels
        {
            get { return 4; }
        }
        public override int MaxSpeed
        {
            get { return 350; }
        }

        public override void Run()
        {
            Console.WriteLine($"I am {TransformerName} - My Wells is {Wheels} and MaxSpeed is {MaxSpeed}.");
        }
    }

    public class Boat : Transformer
    {
        private const string TransformerName = "Boat";

        public override int Wheels
        {
            get { return 0; }
        }
        public override int MaxSpeed
        {
            get { return 200; }
        }

        public override void Run()
        {
            Console.WriteLine($"I am {TransformerName} - My Wells is {Wheels} and MaxSpeed is {MaxSpeed}.");
        }
    }

    public class TransformerFactory
    {
        private static readonly  IDictionary<LandScape, Func<Transformer>> Creator = 
            new Dictionary<LandScape, Func<Transformer>>()
            {
                { LandScape.Air, () => new Jet() },
                { LandScape.Road, () => new Car() },
                { LandScape.Water, () => new Boat() },
            };

        public static Transformer CreateInstance(LandScape landScape)
        {
            return Creator[landScape]();
        }
    }
}
