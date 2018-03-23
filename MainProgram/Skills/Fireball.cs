using System;
using System.Collections.Generic;
using System.Text;

namespace MainProgram
{
    public class Fireball : Skill
    {
        public Fireball()
        {
            requiredAttributes = new Attributes(0, 10, 0);
        }

        public override double GetDamage()
        {
            return (requiredAttributes.intellect * 2.5);
        }
    }
}
