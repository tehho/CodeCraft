using System;
using System.Collections.Generic;
namespace MainProgram
{
    public class Location : Entity
    {
        public delegate void EnterHandler();

        protected readonly List<Location> Locations;

        protected Location(List<Location> locations, string name, string description)
            : base(name, description)
        {
            Locations = locations ?? new List<Location>();
        }

        /// <summary>
        /// Returns a new Location upon entering a correct option.
        /// </summary>
        /// <returns></returns>
        public EnterHandler Enter;

    }
}