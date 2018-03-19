namespace MainProgram
{
    public class Attributes
    {
        public int strengt, intellect, agility;
        public static bool operator< (Attributes attributes, Attributes other)
        {
            return attributes.strengt < other.strengt && attributes.intellect < other.intellect && attributes.agility < other.agility ;
        }
        public static bool operator> (Attributes attributes, Attributes other)
        {
            return false;
        }
    }
}
