using System; 

namespace MainProgram
{
    public abstract class Skill : IAttack
    {
        protected Attributes requiredAttributes;

        public abstract double GetDamage();
    }
}
