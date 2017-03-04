using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Proxy
{
    public abstract class Math
    {
        public abstract double Add(double x, double y);

        public abstract double Sub(double x, double y);

        public abstract double Multi(double x, double y);

        public abstract double Div(double x, double y);
    }

    public class MathImpl : Math
    {
        public override double Add(double x, double y)
        {
            return x + y;
        }

        public override double Sub(double x, double y)
        {
            return x - y;
        }

        public override double Multi(double x, double y)
        {
            return x * y;
        }

        public override double Div(double x, double y)
        {
            return x / y;
        }
    }

    public class MathProxy : Math
    {
        private readonly Math _math = new MathImpl();

        public override double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public override double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }

        public override double Multi(double x, double y)
        {
            return _math.Multi(x, y);
        }

        public override double Div(double x, double y)
        {
            return _math.Div(x, y);
        }
    }

    public class Realtime
    {
        public static void Run()
        {
            var calculator = new MathProxy();
            var add = calculator.Add(1, 2);
            Console.WriteLine($"Add(1,2) = {add}");

            var sub = calculator.Sub(2, 1);
            Console.WriteLine($"Sub(2,1) = {sub}");

            var multi = calculator.Multi(2, 6);
            Console.WriteLine($"Multi(2,6) = {multi}");

            var div = calculator.Div(10, 2);
            Console.WriteLine($"Div(10,2) = {div}");
        }
    }
}
