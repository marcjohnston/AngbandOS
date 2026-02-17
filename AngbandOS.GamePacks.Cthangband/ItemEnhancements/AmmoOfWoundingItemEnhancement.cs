namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfWoundingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "20"),
        (nameof(ToDamageAttribute), "1d6"),
        (nameof(MeleeToHitAttribute), "1d6"),
        (nameof(TreasureRatingAttribute), "5"),
    };
    public override string? FriendlyName => "of Wounding";
}
