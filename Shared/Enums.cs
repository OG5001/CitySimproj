using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    public enum BuildingType
    {
        Residential,
        Industrial,
        Commercial,
        Service,
        Utility
    }
    public enum Residential
    {
        House,
        ApartmentBlock,
        Villa,
        Townhouse,
        Dormitory,
        StudentHousing,
        RetirementHome,
        Hotel
    }

    public enum Industrial
    {
        Factory,
        Warehouse,
        Workshop,
        PowerPlant,
        OilRefinery,
        SteelMill,
        LogisticsCenter,
        RecyclingPlant
    }

    public enum Commercial
    {
        Shop,
        Supermarket,
        ShoppingMall,
        Restaurant,
        Cafe,
        OfficeBuilding,
        Bank,
        Cinema
    }

    public enum Service
    {
        School,
        University,
        Hospital,
        PoliceStation,
        FireStation,
        PostOffice,
        Library,
        CityHall,
        Court,
        Uszoda
    }

    public enum Utility
    {
        WaterTower,
        WaterTreatmentPlant,
        SewagePlant,
        PowerSubstation,
        WindTurbine,
        SolarPlant,
        GasStation,
        WasteProcessing,
        Landfill
    }
}
