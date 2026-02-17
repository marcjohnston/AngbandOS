namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponBlessedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(AbilityItemEnhancementWeightedRandom);
    public override bool? Blessed => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(WisdomAttribute), "1d3"),
    };
    public override string? FriendlyName => "(Blessed)";
}
