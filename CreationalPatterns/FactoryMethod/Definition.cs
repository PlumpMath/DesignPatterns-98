using System;
using System.Collections.Generic;

namespace CreationalPatterns.FactoryMethod
{
    public class Definition
    {
        public static void Run()
        {
            var product = new ProductACreator().CreateProduct();
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
        public virtual IProduct CreateProduct()
        {

        }
    }

    public class ProductACreator : ProductCreator
    {
        public override Product CareteProduct()
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
