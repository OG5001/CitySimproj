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
    class Tornado : NaturalDisasterBlueprint
    {
        public Tornado() : base("Tornado", "A tornado has torn through the city.", 20, 40) { }
    }
    class Hurricane : NaturalDisasterBlueprint
    {
        public Hurricane() : base("Hurricane", "An enormous hurricane has battered the city.", 40, 80) { }
    }
    class VolcanicEruption : NaturalDisasterBlueprint
    {
        public VolcanicEruption() : base("VolcanicEruption", "A volcanic eruption has engulfed the city.", 30, 60) { }
    }
    class Wildfire : NaturalDisasterBlueprint
    {
        public Wildfire() : base("Wildfire", "A wildfire has spread across the city.", 10, 40) { }
    }
    class MeteorImpact : NaturalDisasterBlueprint
    {
        public MeteorImpact() : base("MeteorImpact", "A meteor has crashed into the city.", 20, 50) { }
    }
    class Sinkhole : NaturalDisasterBlueprint
    {
        public Sinkhole() : base("Sinkhole", "A sinkhole has swallowed parts of the city.", 30, 40) { }
    }
    class Landslide : NaturalDisasterBlueprint
    {
        public Landslide() : base("Landslide", "A landslide has crushed everything in its path.", 10, 30) { }
    }
    class FlashFlood : NaturalDisasterBlueprint
    {
        public FlashFlood() : base("FlashFlood", "A flash flood has flooded the city streets.", 10, 20) { }
    }
}