namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfSlayingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "20"),
        (nameof(ToDamageAttribute), "1d12"),
        (nameof(MeleeToHitAttribute), "1d12"),
        (nameof(TreasureRatingAttribute), "15"),
    };
    public override string? FriendlyName => "of Slaying";
}
