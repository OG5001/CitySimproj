namespace Varos_Gazdasag;

internal class EnergySystem
{
    private int production;
    private int consumption;
    private int amount;
    
    public EnergySystem(int production, int consumption, int amount)
    {
        this.production = production;
        this.consumption = consumption;
        this.amount = amount;
    }
    
    public int Production { get => production; set => production = value; }
    public int Consumption { get => consumption; set => consumption = value; }
    public int Amount { get => amount; set => amount = value; }

    public virtual int Produce()
    {
        return production * amount;
    }

    public virtual int Consume()
    {
        return consumption * amount;
    }

    public override string ToString()
    {
        return $"Production: {production} Consumption: {consumption} Amount: {amount}";
    }
}