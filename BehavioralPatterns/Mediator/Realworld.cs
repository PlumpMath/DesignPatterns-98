using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Mediator
{
    public abstract class Participant
    {
        protected readonly AbstractChatroom Chatroom;

        protected Participant(string name, AbstractChatroom chatroom)
        {
            Name = name;
            Chatroom = chatroom;
        }

        public string Name { get; }

        public void Send(Participant to, string message)
        {
            Chatroom.Send(this, to, message);
        }

        public virtual void Notify(string message)
        {
            
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Beatle:Participant
    {
        public Beatle(string name, AbstractChatroom chatroom) : base(name, chatroom)
        {
        }

        public override void Notify(string message)
        {
            Console.WriteLine($"Beatle:{Name} received message:{message}.");
        }
    }

    public class NoBeatle:Participant
    {
        public NoBeatle(string name, AbstractChatroom chatroom) : base(name, chatroom)
        {
        }

        public override void Notify(string message)
        {
            Console.WriteLine($"NoBeatle:{Name} received message:{message}.");
        }
    }

    public abstract class AbstractChatroom
    {
        protected readonly IDictionary<string, Participant> Participants;

        protected AbstractChatroom()
        {
            Participants = new Dictionary<string, Participant>();
        }

        public void AddParticipant(Participant participant)
        {
            Participants[participant.Name] = participant;
        }

        public abstract void Send(Participant from, Participant to, string message);
    }

    public class Chatroom : AbstractChatroom
    {
        public override void Send(Participant from, Participant to, string message)
        {
            Console.WriteLine($"Message is sending from {from} to {to}.");
            if (Participants.ContainsKey(to.Name))
            {
                to.Notify(message);
            }
        }
    }



    public class Realworld
    {
        public static void Run()
        {
            var chatroom = new Chatroom();
            var edison = new Beatle("Edison", chatroom);
            var russel = new Beatle("Russel", chatroom);
            var kk = new Beatle("KK", chatroom);

            chatroom.AddParticipant(edison);
            chatroom.AddParticipant(russel);
            chatroom.AddParticipant(kk);
            edison.Send(russel, "hi, how are you.");
            russel.Send(edison, "hi, i'm fine and you?");
        }
    }
}
