namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? HideType => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-5"),
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "-11000"),
    };
    public override string? HatesElectricity => "true";
    public override bool? Valueless => true;
}
