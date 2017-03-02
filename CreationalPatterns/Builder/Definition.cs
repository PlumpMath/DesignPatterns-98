using System;
using System.Collections.Generic;

namespace CreationalPatterns.Builder
{
    public interface IProduct
    {
        void AddPart(string partName);
        void DisplayDetail();
    }

    public class Product : IProduct
    {
        private static readonly IList<string> Parts = new List<string>();

        public void AddPart(string partName)
        {
            Parts.Add(partName);
        }

        public void DisplayDetail()
        {
            foreach (var part in Parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    public interface IBuilder
    {
        void BuildPartA(string partName);

        void BuildPartB(string partName);

        IProduct GetProduct();
    }

    public class ConcreteBuilderA : IBuilder
    {
        private static readonly IProduct Product = new Product();

        public void BuildPartA(string partName)
        {
            Product.AddPart(partName);
        }

        public void BuildPartB(string partName)
        {
            Product.AddPart(partName);
        }

        public IProduct GetProduct()
        {
            return Product;
        }
    }

    public class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.BuildPartA("partA");
            builder.BuildPartB("partB");
        }
    }

    internal class Definition
    {
        public static void Run()
        {
            var builder = new ConcreteBuilderA();
            var director = new Director();
            director.Construct(builder);
            var product = builder.GetProduct();
            product.DisplayDetail();
        }
    }
}
