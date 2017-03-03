using System;
using System.Collections.Generic;

namespace CreationalPatterns.Prototype
{
    public class Realworld
    {
        public static void Run()
        {
            var colorManager = new ColorManager();
            colorManager["Red"] = new Color(255, 0, 0) {Tag = new ColorTag("red context")};
            colorManager["Green"] = new Color(0, 255, 0);
            colorManager["Blue"] = new Color(0, 0, 255);

            Console.WriteLine(colorManager["Red"].ToString());
            Console.WriteLine(colorManager["Red"].Tag);

            var red = colorManager["Red"].Clone();
            red.Tag.Context = "new red context";
            red.Red = 200;

            Console.WriteLine(colorManager["Red"].ToString());
            Console.WriteLine(colorManager["Red"].Tag);
        }
    }

    public abstract class ColorPrototype
    {
        public virtual int Red { get; set; }

        public virtual int Green { get; set; }

        public virtual int Blue { get; set; }

        public virtual ColorTag Tag { get; set; }

        public abstract ColorPrototype Clone();
    }

    public class Color : ColorPrototype
    {
        public Color(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public override int Red { get; set; }

        public override int Green { get; set; }

        public override int Blue { get; set; }

        public override ColorTag Tag { get; set; }

        public override ColorPrototype Clone()
        {
            return MemberwiseClone() as ColorPrototype;
        }

        public override string ToString()
        {
            return $"Red:{Red},Green:{Green},Blue:{Blue}";
        }
    }

    public class ColorManager
    {
        private static readonly IDictionary<string,ColorPrototype> ColorsDict = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get { return ColorsDict[key]; }
            set { ColorsDict[key] = value; }
        }
    }

    public class ColorTag
    {
        public ColorTag(string context)
        {
            Context = context;
        }

        public string Context { get; set; }

        public override string ToString()
        {
            return $"Current tag is {Context}";
        }
    }
}
