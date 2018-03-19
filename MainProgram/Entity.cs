namespace MainProgram
{
    public class Entity
    {
        protected string name;
        protected string description;
        public string Name { get { return name; } }
        public string Description { get { return description; } }

        public Entity()
        {
            name = "EMPTY";
            description = "EMPTY";
        }

        public Entity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public override string ToString()
        {
            return $"My name is: {name}.\n{description}";
        }

    }
}
