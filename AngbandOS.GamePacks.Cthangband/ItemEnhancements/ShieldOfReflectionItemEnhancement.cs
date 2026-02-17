namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShieldOfReflectionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "15000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(BonusArmorClassAttribute), "1d5"),
    };
    public override string? FriendlyName => "of Reflection";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? Reflect => true;
}
