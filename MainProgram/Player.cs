using System;
using System.Collections.Generic;

namespace MainProgram
{
    public class Player : Character
    {
        
        
        public Player()
            : base()
        {
        }

        public bool PickUp(Item item)
        {
            if (inventory.Count < MAX_Inventory)
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
        
        public static Player CreateNewPlayer()
        {
            return new Player
            {
                name = Input.GetInputWithMessage("Please enter your name:").ToCapitalize(),
                description = Input.GetInputWithMessage("Please enter your description:"),
            };
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Logic()
        {
            throw new NotImplementedException();
        }
    }
}
