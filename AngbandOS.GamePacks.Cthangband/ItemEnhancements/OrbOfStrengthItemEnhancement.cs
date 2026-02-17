namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrbOfStrengthItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
    };
    public override string? FriendlyName => "of Strength";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
        public override bool? SustStr => true;
}
