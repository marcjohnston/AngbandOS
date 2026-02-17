namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfDragonBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "6000"),
        (nameof(TreasureRatingAttribute), "24"),
        (nameof(ConstitutionAttribute), "1d1"),
        (nameof(SlayDragonAttribute), "5"),
    };
    public override string? FriendlyName => "of Dragon Bane";
}
