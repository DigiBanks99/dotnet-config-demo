namespace ConfigLib;

public record Wheel
{
    public Wheel()
    {
    }

    public Wheel(string model = "Unset", decimal diameter = decimal.MinValue)
    {
        Model = model;
        Diameter = diameter;
    }

    public string? Model { get; init; }
    public decimal Diameter { get; init; }
}