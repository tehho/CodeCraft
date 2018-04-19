namespace MainProgram
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected Entity()
        {
            Name = "EMPTY";
            Description = "EMPTY";
        }

        protected Entity(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"My name is: {Name}.\n{Description}"; 
        }

    }
}
