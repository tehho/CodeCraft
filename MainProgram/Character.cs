using System.Collections.Generic;
using System.Linq;

namespace MainProgram
{
    public abstract class Character : Entity
    {
        public Attributes Stats
        {
            get => Stats;
            set => Stats = value;
        }

        protected readonly List<Item> Inventory;
        public int MaxInventory => 10 + Stats.strengt;

        protected Equipment[] Equipments;

        public int MaxHealth => Stats.strengt * 3;
        public int Health { get; set; }

        protected Character()
            : base()
        {
            Stats = new Attributes();
            Inventory = new List<Item>();
            Equipments = new Equipment[14];
        }
        public abstract void Logic();
    }
}
