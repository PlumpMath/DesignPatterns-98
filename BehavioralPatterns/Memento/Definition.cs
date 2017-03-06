using System;

namespace BehavioralPatterns.Memento
{
    public class Originator
    {
        public void SetMemento(Memento memento)
        {
            Name = memento.Name;
            Address = memento.Address;
        }

        public string Name { get; set; }
        public string Address { get; set; }

        public Memento RestoreMemento()
        {
            return new Memento(Name, Address);
        }

        public void DisplayBasicInfo()
        {
            Console.WriteLine($"{Name}-{Address}");
        }
    }

    public class Caretaker
    {
        public Memento Memento { get; set; }
    }

    public class Memento
    {
        public Memento(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Definition
    {
        public static void Run()
        {
            var originator = new Originator();
            originator.Name = "Name1";
            originator.Address = "Address1";
            originator.DisplayBasicInfo();
            var caretaker = new Caretaker
            {
                Memento = originator.RestoreMemento()
            };
            originator.Name = "Name2";
            originator.Address = "Address2";
            originator.DisplayBasicInfo();
            originator.SetMemento(caretaker.Memento);
            originator.DisplayBasicInfo();
        }
    }
}
