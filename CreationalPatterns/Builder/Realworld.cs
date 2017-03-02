using System;
using System.Collections.Generic;

namespace CreationalPatterns.Builder
{
    public enum VehicleType
    {
        MotoCycle,
        Car,
        Electic
    }

    public interface IVehicle
    {
        VehicleType Type { get; }

        void DisplayDetail();
    }

    public class Vehicle : IVehicle
    {
        private static readonly Dictionary<string, string> Parts = new Dictionary<string, string>();

        public VehicleType Type { get; }

        public string this[string key]
        {
            get { return Parts[key]; }
            set { Parts[key] = value; }
        }

        public void DisplayDetail()
        {
            foreach (var part in Parts)
            {
                Console.WriteLine(part.Value);
            }
        }
    }

    public interface IVehicleBuilder
    {
        void BuildA();

        void BuildB();

        IVehicle GetVehicle();
    }

    public abstract class BuilderBase : IVehicleBuilder
    {
        protected static readonly Vehicle Vehicle = new Vehicle();

        public void Build()
        {
            BuildA();
            BuildB();
        }

        public virtual void BuildA()
        {

        }

        public virtual void BuildB()
        {

        }

        public IVehicle GetVehicle()
        {
            return Vehicle;
        }
    }

    public class CarBuilder : BuilderBase
    {
        public override void BuildA()
        {
            Vehicle["PartA"] = "Car item A";
        }

        public override void BuildB()
        {
            Vehicle["PartB"] = "Car item B";
        }
    }

    public class MotoBuilder : BuilderBase
    {
        public override void BuildA()
        {
            Vehicle["PartA"] = "Moto item A";
        }

        public override void BuildB()
        {
            Vehicle["PartB"] = "Moto item B";
        }
    }

    public class RealwordDirector
    {
        public void Construct(IVehicleBuilder builder)
        {
            builder.BuildA();
            builder.BuildB();
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var builder = new MotoBuilder();
            var director = new RealwordDirector();
            director.Construct(builder);
            var vehicle = builder.GetVehicle();
            vehicle.DisplayDetail();
        }
    }
}
