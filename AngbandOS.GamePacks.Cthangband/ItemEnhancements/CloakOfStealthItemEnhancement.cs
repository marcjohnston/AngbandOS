namespace AngbandOS.GamePacks.Cthangband;

public class CloakOfStealthItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(StealthAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Stealth";
}
