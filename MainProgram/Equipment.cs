namespace MainProgram
{
    public class Equipment : Item
    {
        int durability;
        int MAX_durability;
        public Attributes stats;
        public Equipment()
            : base()
        {
            MAX_durability = 100;
            durability = MAX_durability;
        }
    }
}
