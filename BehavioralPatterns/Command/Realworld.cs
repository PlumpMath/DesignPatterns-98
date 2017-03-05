using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Command
{
    public enum OperatorType
    {
        Add,
        Sub,
        Multi,
        Div
    }

    public interface ICalculatorCommand
    {
        void Execute();
        void UnExecute();
    }

    public class CalculatorCommand : ICalculatorCommand
    {
        private readonly ICalculator _calculator;
        private readonly OperatorType _operatorType;
        private readonly double _operand;

        public CalculatorCommand(ICalculator calculator, OperatorType operatorType, double operand)
        {
            _calculator = calculator;
            _operatorType = operatorType;
            _operand = operand;
        }

        public void Execute()
        {
            _calculator.Calculate(_operatorType, _operand);
        }

        public void UnExecute()
        {
            _calculator.Calculate(GetReverseOperatorType(), _operand);
        }

        private OperatorType GetReverseOperatorType()
        {
            switch (_operatorType)
            {
                case OperatorType.Add:
                    return OperatorType.Sub;
                case OperatorType.Sub:
                    return OperatorType.Add;
                case OperatorType.Multi:
                    return OperatorType.Div;
                case OperatorType.Div:
                    return OperatorType.Multi;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public interface ICalculator
    {
        void Calculate(OperatorType operatorType, double operand);
    }

    public class Calculator : ICalculator
    {
        public Calculator()
        {
            Result = 0;
        }

        public double Result { get; private set; }

        public void Calculate(OperatorType operatorType, double operand)
        {
            switch (operatorType)
            {
                case OperatorType.Add:
                    Result += operand;
                    break;
                case OperatorType.Sub:
                    Result -= operand;
                    break;
                case OperatorType.Multi:
                    Result *= operand;
                    break;
                case OperatorType.Div:
                    Result /= operand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operatorType), operatorType, null);
            }

            Console.WriteLine($"Current result is {Result}");
        }
    }

    public class User
    {
        private readonly IList<ICalculatorCommand> _commands = new List<ICalculatorCommand>();
        private readonly Calculator _calculator = new Calculator();

        public void Compute(OperatorType operatorType, double operand)
        {
            var command = new CalculatorCommand(_calculator, operatorType, operand);
            _commands.Add(command);
            command.Execute();
        }

        public void Undo(int steps)
        {
            if (steps > _commands.Count)
            {
                steps = _commands.Count;
            }

            for (var index = _commands.Count - 1; index >= _commands.Count - steps; index--)
            {
                _commands[index].UnExecute();
            }
        }

        public void Redo(int steps)
        {
            if (steps > _commands.Count)
            {
                steps = _commands.Count;
            }

            for (var index = _commands.Count - steps; index < _commands.Count; index++)
            {
                _commands[index].Execute();
            }
        }
    }

    public class Realworld
    {
        public static void Run()
        {
            var user = new User();
            user.Compute(OperatorType.Add, 5);
            user.Compute(OperatorType.Add, 10);
            user.Compute(OperatorType.Add, 20);
            user.Compute(OperatorType.Add, 30);
            user.Compute(OperatorType.Sub, 30);
            user.Compute(OperatorType.Multi, 2);
            user.Compute(OperatorType.Div, 3);

            user.Undo(2);
            user.Redo(5);
        }
    }
}
