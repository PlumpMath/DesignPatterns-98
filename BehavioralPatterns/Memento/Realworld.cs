using System;

namespace BehavioralPatterns.Memento
{
    public class SalesRrospect
    {
        public double Budget { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }

        public void SetProspect(ProspectMemento memento)
        {
            Budget = memento.Budget;
            City = memento.City;
            ProductName = memento.ProductName;
        }

        public ProspectMemento RestoreMemento()
        {
            return new ProspectMemento(ProductName, City, Budget);
        }

        public void Display()
        {
            Console.WriteLine($"{ProductName}-{City}-{Budget}");
        }
    }

    public class ProspectMemento
    {
        public ProspectMemento(string productName, string city, double budget)
        {
            ProductName = productName;
            City = city;
            Budget = budget;
        }

        public double Budget { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }
    }

    public class ProspectMemory
    {
        public ProspectMemento Memento { get; set; }
    }

    public class Realworld
    {
        public static void Run()
        {
            var salesProspect = new SalesRrospect
            {
                ProductName = "P1", City = "C1", Budget = 10000
            };
            salesProspect.Display();
            var prospectMemory = new ProspectMemory
            {
                Memento = salesProspect.RestoreMemento()
            };
            salesProspect.ProductName = "product1";
            salesProspect.City = "city1";
            salesProspect.Budget = 20000;
            salesProspect.Display();
            salesProspect.SetProspect(prospectMemory.Memento);
            salesProspect.Display();
        }
    }
}
