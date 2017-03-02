using System;

namespace CreationalPatterns.AbstractFactory
{
    public interface IWheel
    {
        string GetDescription();
    }

    public class BenzWheel : IWheel
    {
        public string GetDescription()
        {
            return "Benz wheel";
        }
    }

    public class BmwWheel:IWheel
    {
        public string GetDescription()
        {
            return "Bmw wheel";
        }
    }

    public interface ITire
    {
        string GetModel();
    }

    public class BenzTire:ITire
    {
        public string GetModel()
        {
            return "Bena tire";
        }
    }

    public class BmwTire:ITire
    {
        public string GetModel()
        {
            return "Bmw tire";
        }
    }

    public interface IWholeTireFactory
    {
        IWheel CreateWheel();

        ITire CreateTire();
    }

    public class BenzWholeTireFactory : IWholeTireFactory
    {
        public IWheel CreateWheel()
        {
            return new BenzWheel();
        }

        public ITire CreateTire()
        {
            return new BenzTire();
        }
    }

    public class BmwWhoeWheelFactory:IWholeTireFactory
    {
        public IWheel CreateWheel()
        {
            return new BmwWheel();
        }

        public ITire CreateTire()
        {
            return new BmwTire();
        }
    }

    internal class Realworld
    {
        public static void Run()
        {
            var wholeTire = new BmwWhoeWheelFactory();
            Console.WriteLine($"{wholeTire.CreateTire().GetModel()} {wholeTire.CreateWheel().GetDescription()}");
        }
    }
}
