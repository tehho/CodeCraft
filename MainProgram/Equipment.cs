namespace MainProgram
{
    public class Equipment : UsabelItem
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
