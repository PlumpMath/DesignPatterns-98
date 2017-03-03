using System;

namespace CreationalPatterns.FactoryMethod
{
    public class Definition
    {
        public static void Run()
        {
            var product = new ProductBCreator().CreateProduct();
            Console.WriteLine(product);
        }
    }

    public abstract class Product
    {

    }

    public class ProductA : Product
    {
        public override string ToString()
        {
            return "product A";
        }
    }

    public class ProductB : Product
    {
        public override string ToString()
        {
            return "product B";
        }
    }

    public abstract class ProductCreator
    {
        public virtual Product CreateProduct()
        {
            return default(Product);
        }
    }

    public class ProductACreator : ProductCreator
    {
        public override Product CreateProduct()
        {
            return new ProductA();
        }
    }

    public class ProductBCreator : ProductCreator
    {
        public override Product CreateProduct()
        {
            return new ProductB();
        }
    }
}
