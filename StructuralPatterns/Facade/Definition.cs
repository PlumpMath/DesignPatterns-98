using System;

namespace StructuralPatterns.Facade
{
    public class Facade
    {
        private static readonly SubSystemOne One = new SubSystemOne();
        private static readonly SubSytemTwo Two = new SubSytemTwo();
        private static readonly SubStytemThree Three = new SubStytemThree();

        public void Startup()
        {
            One.ExecuteStepOne();
            Two.ExecuteStepTwo();
            Three.ExecuteStepThree();
        }

        public void Close()
        {
            One.Close();
            Two.Close();
            Three.Close();
        }
    }

    public class SubSystemOne
    {
        public void ExecuteStepOne()
        {
            Console.WriteLine("Step one.");
        }

        public void Close()
        {
            Console.WriteLine("Close one.");
        }
    }

    public class SubSytemTwo
    {
        public void ExecuteStepTwo()
        {
            Console.WriteLine("Step two.");
        }

        public void Close()
        {
            Console.WriteLine("Close two.");
        }
    }

    public class SubStytemThree
    {
        public void ExecuteStepThree()
        {
            Console.WriteLine("Step three.");
        }

        public void Close()
        {
            Console.WriteLine("Close three.");
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var facade = new Facade();
            facade.Startup();
            facade.Close();
        }
    }
}
