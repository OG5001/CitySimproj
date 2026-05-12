namespace CitySimproj.Events
{
    class Earthquake : NaturalDisasterBlueprint
    {
        public Earthquake() : base("Earthquake", "The city was shaken by a massive earthquake.", 20, 50) { }
    }
    class Tsunami : NaturalDisasterBlueprint
    {
        public Tsunami() : base("Tsunami", "A devastating tsunami has struck the city.", 30, 60) { }
    }
}