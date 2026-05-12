namespace CitySimproj.Events
{
    abstract class EconomicsEventsBlueprint : IEvent
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public EconomicsEventsBlueprint(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void StartEffect() { }
    }

}