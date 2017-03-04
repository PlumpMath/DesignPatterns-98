using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace StructuralPatterns.Flyweight
{
    public class CharacterFactory
    {
        private readonly IDictionary<string, Character> _characters = new ConcurrentDictionary<string, Character>();

        public Character GetCharacter(string name)
        {
            if (_characters.ContainsKey(name))
            {
                return _characters[name];
            }
            else
            {
                var character = default(Character);
                switch (name)
                {
                    case "A":
                        character = new CharacterA("A");
                        _characters[name] = character;
                    break;
                    case "B":
                        character = new CharacterB("B");
                        _characters[name] = character;
                        break;
                }

                return character;
            }
        }
    }

    public abstract class Character
    {
        protected Character(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }
    }

    public class CharacterA : Character
    {
        public CharacterA(string name) : base(name)
        {
            Width = 1;
            Height = 1;
        }
    }

    public class CharacterB : Character
    {
        public CharacterB(string name) : base(name)
        {
            Width = 2;
            Height = 2;
        }
    }


    public class Realtime
    {
        public static void Run()
        {
            var characterFactory = new CharacterFactory();
            var characterA = characterFactory.GetCharacter("A");
            var characterB = characterFactory.GetCharacter("B");
            PrintCharacterInfo(characterA);
            PrintCharacterInfo(characterB);
        }

        private static void PrintCharacterInfo(Character c)
        {
            Console.WriteLine($"Character {c.Name} {c.Width} {c.Height}");
        }
    }
}
