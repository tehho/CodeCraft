using System;
using System.Collections.Generic;
using System.Linq;

namespace MainProgram
{
    public class Location : Entity
    {
        public delegate Location EnterHandler();

        public List<Location> _locations { get; private set; }
        private readonly DialogOptions _options;
        private readonly Location _parent;

        public EnterHandler Enter;

        public Location(List<Location> locations, string name, string description, Location parent, params EnterHandler[] events)
            : base(name, description)
        {
            _parent = parent;
            _locations = locations ?? new List<Location>();
            _options = new DialogOptions("What do you want to do?");

            foreach (var e in events)
            {
                Enter += e;
            }

             
            Enter += () => _parent;

        }

        public Location(string name, string description, Location parent, params EnterHandler[] events)
            : this(null, name, description, parent, events)
        {
        }

        public void AddInput()
        {
            Enter += Logic;
        }


        public void AddEvent(EnterHandler e)
        {
            Enter += e;
        }

        public void AddLocation(Location location, string option = "")
        {
            _locations.Add(location);

            _options.AddDialogOption(new DialogOption(location.Name + "," + option));
        }
        public void AddLocation(Location location, params string[] option)
        {
            AddLocation(location, string.Join(",", option));
        }

        public Location Display()
        {
            Input.DisplayText(this);
            return null;
        }

        public Location Logic()
        {
            var input = Input.GetInputFromOptions(_options);

            var list = _locations.Where((item) => item.Name == input).ToList();

            if (list.Count == 0)
                throw new ArgumentException("Input not valid!", nameof(input));

            return list[0];
        }

    }
}