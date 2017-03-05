using System;

namespace BehavioralPatterns.Command
{
    public class Definition
    {
        public static void Run()
        {
            Client.Entry();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class ConcreteCommand : ICommand
    {
        private readonly IReceiver _receiver;

        public ConcreteCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.HandleLogic();
        }
    }

    public interface IReceiver
    {
        void HandleLogic();
    }

    public class Receiver : IReceiver
    {
        public void HandleLogic()
        {
            Console.WriteLine("Do some additional logic in receiver.");
        }
    }

    public class Client
    {
        public static void Entry()
        {
            var receiver = new Receiver();
            var command = new ConcreteCommand(receiver);
            command.Execute();
        }
    }
}
