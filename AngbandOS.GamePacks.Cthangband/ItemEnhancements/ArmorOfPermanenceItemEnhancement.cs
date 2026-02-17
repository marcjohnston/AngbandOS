namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorOfPermanenceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(ResistanceItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "30000"),
        (nameof(BonusArmorClassAttribute), "1d10"),
        (nameof(TreasureRatingAttribute), "30"),
    };
    public override string? FriendlyName => "of Permanence";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SustCha => true;
    public override bool? SustCon => true;
    public override bool? SustDex => true;
    public override bool? SustInt => true;
    public override bool? SustStr => true;
    public override bool? SustWis => true;
}
