namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "15"),
    };
    public override string? FriendlyName => "of Slaying";
}
