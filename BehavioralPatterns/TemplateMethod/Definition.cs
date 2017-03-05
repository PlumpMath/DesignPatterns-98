using System;

namespace BehavioralPatterns.TemplateMethod
{
    public abstract class BallGenerator
    {
        public void Generate()
        {
            GenerateSerialNumber();
            GenerateAddress();
        }

        protected abstract void GenerateSerialNumber();

        protected abstract void GenerateAddress();

    }

    public class BasketballGenerator : BallGenerator
    {
        protected override void GenerateSerialNumber()
        {
            Console.WriteLine($"Basketball serial number {Guid.NewGuid()}");
        }

        protected override void GenerateAddress()
        {
            Console.WriteLine($"Basketball address {Guid.NewGuid()}");
        }
    }

    public class FootballGenerator : BallGenerator
    {
        protected override void GenerateSerialNumber()
        {
            Console.WriteLine($"Football serial number {Guid.NewGuid()}");
        }

        protected override void GenerateAddress()
        {
            Console.WriteLine($"Football address {Guid.NewGuid()}");
        }
    }

    class Definition
    {
        public static void Run()
        {
            var football = new FootballGenerator();
            football.Generate();

            var basketball = new BasketballGenerator();
            basketball.Generate();
        }
    }
}
