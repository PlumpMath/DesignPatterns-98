using System;

namespace CreationalPatterns.Prototype
{
    public abstract class Prototype
    {
        public string Id { get; set; }

        public Prototype(string id)
        {
            Id = id;
        }

        public abstract Prototype Copy();
    }

    public class ContretePrototype1 : Prototype
    {
        public ContretePrototype1(string id) : base(id)
        {

        }

        public override Prototype Copy()
        {
            return MemberwiseClone() as Prototype;
        }
    }

    public class ConcretePrototype2: Prototype
    {
        public ConcretePrototype2(string id) : base(id)
        {

        }

        public override Prototype Copy()
        {
            return MemberwiseClone() as Prototype;
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var concretePrototype = new ConcretePrototype2(Guid.NewGuid().ToString());
            Console.WriteLine(concretePrototype.Id);
            var prototype = concretePrototype.Copy();
            Console.WriteLine(prototype.Id);

            concretePrototype.Id = Guid.NewGuid().ToString();
            Console.WriteLine(concretePrototype.Id);
            Console.WriteLine(prototype.Id);
        }
    }
}
