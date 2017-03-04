using System;

namespace BehavioralPatterns.State
{
    public class Context
    {
        public StateBase StateBase { get; set; }

        public Context(StateBase stateBase)
        {
            StateBase = stateBase;
        }

        public void Request()
        {
            Console.WriteLine("Context request is invoked.");
            StateBase.Handle(this);
        }
    }

    public abstract class StateBase
    {
        public abstract void Handle(Context c);
    }

    public class StartStateBase : StateBase
    {
        public override void Handle(Context c)
        {
            c.StateBase = new EndStateBase();
        }
    }

    public class EndStateBase : StateBase
    {
        public override void Handle(Context c)
        {
            c.StateBase = new StartStateBase();
        }
    }

    class Definition
    {
        public static void Run()
        {
            var context = new Context(new StartStateBase());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }

}
