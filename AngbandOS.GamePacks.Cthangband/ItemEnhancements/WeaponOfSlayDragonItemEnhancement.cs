namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayDragonItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(TreasureRatingAttribute), "18"),
    };
    public override string? FriendlyName => "of Slay Dragon";
}
