using System;

namespace CreationalPatterns.AbstractFactory
{
    public interface IProduct
    {
        string Name { get; }
    }

    public class ProductA1 : IProduct
    {
        public ProductA1(string productName)
        {
            Name = productName;
        }

        public string Name { get; }
    }

    public class ProductA2 : IProduct
    {
        public ProductA2(string productName)
        {
            Name = productName;
        }

        public string Name { get; }
    }

    public class ProductB1 : IProduct
    {
        public ProductB1(string productName)
        {
            Name = productName;
        }

        public string Name { get; }
    }

    public class ProductB2 : IProduct
    {
        public ProductB2(string productName)
        {
            Name = productName;
        }

        public string Name { get; }
    }

    public interface IProductFactory
    {
        IProduct CreateProductA(string productName);

        IProduct CreateProductB(string productName);
    }

    public class ProductFactory1 : IProductFactory
    {
        public IProduct CreateProductA(string productName)
        {
            return new ProductA1(productName);
        }

        public IProduct CreateProductB(string productName)
        {
            return new ProductB1(productName);
        }
    }

    public class ProductFactory2 : IProductFactory
    {
        public IProduct CreateProductA(string productName)
        {
            return new ProductA2(productName);
        }

        public IProduct CreateProductB(string productName)
        {
            return new ProductB2(productName);
        }
    }

    internal class Definition
    {
        public static void Run()
        {
            var productFactory = new ProductFactory1();
            var productA = productFactory.CreateProductA("productA");
            var productB = productFactory.CreateProductB("productB");
            Console.WriteLine($"{productA.Name} {productB.Name}");
            
        }
    }
}
