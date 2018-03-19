using System;
using System.Collections.Generic;

namespace MainProgram
{
    public class Player : Character
    {
        readonly List<Item> inventory;
        Equipment[] armor;

        Attributes stats;
        
        public Player()
            : base()
        {
            inventory = new List<Item>();
        }

        public bool PickUp(Item item)
        {
            if (inventory.Count < AllowedMaxInventory())
            {
                inventory.Add(item);
                return true;
            }
            return false;
        }

        public bool DropItem(Item item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                return true;
            }
            return false;
              
        }

        public bool Equip(Equipment item)
        {
            if (item.stats < stats)
            {
                return true;
            }
            return false;
        }

        int AllowedMaxInventory()
        {
            return 10 + stats.strengt;
        }

        public static Player CreateNewPlayer()
        {
            return new Player
            {
                name = Input.GetInputWithMessage("Please enter your name:").ToCapitalize(),
                description = Input.GetInputWithMessage("Please enter your description:"),
                stats = new Attributes()
            };
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
