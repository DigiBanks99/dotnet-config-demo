namespace ConfigLib;

public record Wheel
{
    public Wheel()
    {
        
    }

    public Wheel(string model = "Unset", decimal diameter = decimal.MinValue)
    {
        this.Model = model;
        this.Diameter = diameter;
    }

    public string Model { get; init; }
    public decimal Diameter { get; init; }
}
