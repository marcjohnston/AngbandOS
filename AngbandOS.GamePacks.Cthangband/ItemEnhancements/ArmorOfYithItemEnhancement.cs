namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorOfYithItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(ResistanceItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "15000"),
        (nameof(StealthAttribute), "1d3"),
        (nameof(BonusArmorClassAttribute), "1d10"),
        (nameof(TreasureRatingAttribute), "25"),
    };
    public override string? FriendlyName => "of Yith";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
}
