namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfStealthItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(StealthAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Stealth";
}
