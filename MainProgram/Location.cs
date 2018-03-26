using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using log4net;

namespace MainProgram
{
    public class Location : Entity
    {
        public delegate Location EnterHandler();

        private readonly List<Location> Locations;
        private readonly DialogOptions options;



        public EnterHandler Enter;

        public Location(List<Location> locations, string name, string description)
            : base(name, description)
        {
            Locations = locations ?? new List<Location>();
            Enter += Display;
            Enter += Logic;

        }
        public Location(string name, string description)
            : base(name, description)
        {
            Locations = new List<Location>();
            options = new DialogOptions("What do you want to do?");
            Enter += Display;
            Enter += () =>
            {
                Enter += Logic;
                return null;
            };
        }


        public void AddEvent(EnterHandler e)
        {
            Enter += e;
        }

        public void AddLocation(Location location, string option = "")
        {
            Locations.Add(location);

            var temp = location.Name;

            if (!string.IsNullOrWhiteSpace(option))
            {
                temp += "," + option;
            }

            options.AddDialogOption(new DialogOption(temp));
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
            var input = Input.GetInputFromOptions(options);

            var list = Locations.Where((item) => item.Name == input).ToList();

            if (list.Count == 0)
                throw new ArgumentException("Input not valid!", nameof(input));

            return list[0];

        }

    }
}