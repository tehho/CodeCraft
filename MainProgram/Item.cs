namespace MainProgram
{
    public class Item : Entity
    {
        int value;
        Quality quality;
        int Value { get { return value; } }
        Quality Quality { get { return quality; } }

        public Item()
            : base()
        {
            value = 0;
            quality = Quality.Poor;
        }
    }
}
