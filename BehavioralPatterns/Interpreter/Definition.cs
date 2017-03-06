using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Interpreter
{
    public class Context { }

    public abstract class Expression
    {
        public abstract void Interpret(Context context);
    }

    public class TerminalExpression:Expression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("terminal expression.");
        }
    }

    public class NonTerminalExpression:Expression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("non terminal expression.");
        }
    }

    public class Definition
    {
        public static void Run()
        {
            var context = new Context();
            var expressions = new List<Expression>
            {
                new TerminalExpression(),
                new NonTerminalExpression(),
                new TerminalExpression(),
                new NonTerminalExpression()
            };

            expressions.ForEach(e=>e.Interpret(context));
        }
    }
}
