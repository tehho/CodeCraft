using System;
using System.Collections.Generic;
namespace MainProgram
{
    public class MultiWayLocation : Location
    {
        private readonly DialogOptions _options;

        public MultiWayLocation(List<Location> locations, string name, string description, string question, params string[] options)
            : this(locations, name, description, DialogOptions.CreateOptions(question, locations, options))
        {
        }
        public MultiWayLocation(List<Location> locations, string name, string description, DialogOptions options)
            : base(locations, name, description)
        {
            _options = options ?? throw new NullReferenceException("You need to set Options");
        }

        /// <summary>
        /// Adds a new location to a location
        /// </summary>
        /// <param name="location">The new location</param>
        /// <param name="options">Options on how to reach it</param>
        public void AddLocation(Location location, params string[] options)
        {
            if (location != null)
            {
                Locations.Add(location);

                var ret = location.Name;

                foreach (var option in options)
                {
                    ret += $",{option}";
                }

                _options.AddDialogOption(new DialogOption(ret));
            }
        }

        public override Location Enter()
        {
            var input = Input.GetInputFromOptions(_options);

            foreach (var location in Locations)
            {
                if (location.Name == input)
                    return location;
            }

            throw new ArgumentException($"Input {input} does not exits in the list options", nameof(input));
        }
    }
}