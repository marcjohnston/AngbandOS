namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfEvilBaneItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Blessed => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(WisdomAttribute), "1d2"),
    };
    public override string? FriendlyName => "of Evil Bane";
    public override bool? SlayEvil => true;
}
