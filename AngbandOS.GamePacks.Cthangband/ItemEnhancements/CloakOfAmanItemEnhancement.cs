namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfAmanItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(ResistanceItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(BonusArmorClassAttribute), "1d20"),
        (nameof(StealthAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Aman";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
}
