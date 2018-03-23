using System;
using System.Collections.Generic;
using System.Linq;

namespace MainProgram
{
    public class OneWayLocation : Location
    {
        private readonly List<Action> _doSomeThing;

        public Location Parent
        {
            get => Locations[0];
            set
            {
                Locations.Add(value);
                Locations.RemoveAt(0);
            }
        }


        public OneWayLocation(Location parent, string name, string description, Action doSomeThing)
            : this(parent, name, description, new List<Action>() {doSomeThing}.ToArray())
        {
        }

        public OneWayLocation(Location parent, string name, string description, params Action[] doSomeThing)
            : base(new List<Location>() { parent }, name, description)
        {
            _doSomeThing = new List<Action>(doSomeThing);
        }

        public override Location Enter()
        {
            foreach (var function in _doSomeThing)
            {
                function();
            }
            return Parent;
        }
    }
}