namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponVampiricItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
        (nameof(TreasureRatingAttribute), "25"),
    };
    public override bool? Vampiric => true;
    public override string? FriendlyName => "(Vampiric)";
    public override bool? HoldLife => true;
}
