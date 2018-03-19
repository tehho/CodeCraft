using System;

namespace MainProgram
{
    public class Weapon : Equipment
    {
        int MIN_damage;
        int MAX_damage;

        public Weapon()
            : base()
        {
            MIN_damage = 1;
            MAX_damage = 10;
        }
        public int GetDamage(Random random)
        {
            return random.Next(MIN_damage, MAX_damage + 1);
        }
    }
}
