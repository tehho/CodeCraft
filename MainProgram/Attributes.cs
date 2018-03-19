using System;

namespace MainProgram
{
    public class Attributes
    {
        public int strengt, intellect, agility;

        public Attributes()
        {
            Random rand = new Random();
            strengt = rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6);
            intellect = rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6);
            agility = rand.Next(1, 6) + rand.Next(1, 6) + rand.Next(1, 6);
        }

        public static bool operator< (Attributes attributes, Attributes other)
        {
            return attributes.strengt < other.strengt && attributes.intellect < other.intellect && attributes.agility < other.agility ;
        }
        public static bool operator> (Attributes attributes, Attributes other)
        {
            return attributes.strengt > other.strengt && attributes.intellect > other.intellect && attributes.agility > other.agility;
        }
    }
}
