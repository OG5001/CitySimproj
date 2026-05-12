namespace CitySimproj.Events
{
    public abstract class EventBlueprint
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected EventBlueprint(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void StartEffect();
    }
}