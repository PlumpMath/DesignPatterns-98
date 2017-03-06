using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Interpreter
{
    public class OperationContext
    {
        private readonly IDictionary<OperationExpression, int> _expressions;

        public OperationContext()
        {
            _expressions = new Dictionary<OperationExpression, int>();
        }

        public void AddExpression(OperationExpression expression, int value)
        {
            _expressions.Add(expression, value);
        }

        public int GetExpressionValue(OperationExpression expression)
        {
            return _expressions.ContainsKey(expression) ? _expressions[expression] : 0;
        }
    }

    public abstract class OperationExpression
    {
        public abstract int Interpret(OperationContext context);
    }

    public class ConstantExpression:OperationExpression
    {
        private readonly int _value;

        public ConstantExpression(int value)
        {
            _value = value;
        }

        public override int Interpret(OperationContext context)
        {
            return _value;
        }
    }

    public class VariableExpression: OperationExpression
    {
        public override int Interpret(OperationContext context)
        {
            return context.GetExpressionValue(this);
        }
    }

    public abstract class NonTerminalOperationExpression : OperationExpression
    {
        protected NonTerminalOperationExpression(OperationExpression left, OperationExpression right)
        {
            Left = left;
            Right = right;
        }

        public OperationExpression Left { get; }

        public OperationExpression Right { get; }
    }

    public class AddExpression: NonTerminalOperationExpression
    {
        public AddExpression(OperationExpression left, OperationExpression right) 
            : base(left, right)
        {

        }

        public override int Interpret(OperationContext context)
        {
            return Left.Interpret(context) + Right.Interpret(context);
        }
    }

    public class SubExpression : NonTerminalOperationExpression
    {
        public SubExpression(OperationExpression left, OperationExpression right)
            : base(left, right)
        {

        }

        public override int Interpret(OperationContext context)
        {
            return Left.Interpret(context) - Right.Interpret(context);
        }
    }

    public class MultiExpression : NonTerminalOperationExpression
    {
        public MultiExpression(OperationExpression left, OperationExpression right)
            : base(left, right)
        {
        }

        public override int Interpret(OperationContext context)
        {
            return Left.Interpret(context)*Right.Interpret(context);
        }
    }

    public class DivExpression:NonTerminalOperationExpression
    {
        public DivExpression(OperationExpression left, OperationExpression right)
            : base(left, right)
        {
        }

        public override int Interpret(OperationContext context)
        {
            return Left.Interpret(context)/Right.Interpret(context);
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var constant = new ConstantExpression(10);
            var variable1 = new VariableExpression();
            var variable2 = new VariableExpression();
            var context = new OperationContext();
            context.AddExpression(variable1, 100);
            context.AddExpression(variable2, 200);
            var expression = new AddExpression(constant, new SubExpression(variable2, variable1));
            Console.WriteLine(expression.Interpret(context));
        }
    }
}
