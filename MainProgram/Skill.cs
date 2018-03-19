using System; 

namespace MainProgram
{
    public abstract class Skill : IAttack
    {
        protected Attributes requiredAttributes;

        public abstract int GetDamage();
    }
}
