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
            if (Inventory.Count < MaxInventory)
            {
                Inventory.Add(item);
                return true;
            }
            return false;
        }

        public bool DropItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                Inventory.Remove(item);
                return true;
            }
            return false;
              
        }

        public bool Equip(Equipment item)
        {
            if (item.stats < Stats)
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
