namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbOfIrritationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Irritation";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "-9600"),
    };
}
