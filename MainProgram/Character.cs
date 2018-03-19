using System.Collections.Generic;
using System.Linq;

namespace MainProgram
{
    public abstract class Character : Entity
    {
        public readonly Attributes stats;

        protected readonly List<Item> inventory;
        public int MAX_Inventory { get { return 10 + stats.strengt; } }

        protected Equipment[] armor;
        protected Weapon weapon;
        protected Equipment offhand;

        public int MAX_Health { get { return stats.strengt * 3; } }
        public int Health;
        
        public Character()
            : base()
        {
            stats = new Attributes();
        }
        public abstract void Logic();
    }
}
