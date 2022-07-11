using Ardalis.SmartEnum;

namespace Domain.Enum;

public class Essentiality : SmartEnum<Essentiality>
{
    public static readonly Essentiality Indispensable = new(nameof(Indispensable), "Indispensable", 0);
    public static readonly Essentiality Conditional = new(nameof(Conditional), "Condicional", 1);
    public static readonly Essentiality Dispensable = new(nameof(Dispensable), "Dispensable", 2);

    public Essentiality(string name, string nameDisplay, int value) : base(name, value)
    {
        NameDisplay = nameDisplay;
    }

    public string NameDisplay { get; set; }
}