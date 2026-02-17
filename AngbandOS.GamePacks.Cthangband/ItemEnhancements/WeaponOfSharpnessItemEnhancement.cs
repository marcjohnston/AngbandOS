namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSharpnessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "2"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? FriendlyName => "of Sharpness";
}
