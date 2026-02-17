namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BowOfAccuracyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(MeleeToHitAttribute), "1d15"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Accuracy";
}
