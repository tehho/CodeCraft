using System;
using System.Collections.Generic;
namespace MainProgram
{

    public class Faction : Entity
    {
        List<Faction> friendlies;
        List<Faction> enemies;

        public Faction()
            : base()
        {
            friendlies = new List<Faction>();
            enemies = new List<Faction>();
        }
    }
}
