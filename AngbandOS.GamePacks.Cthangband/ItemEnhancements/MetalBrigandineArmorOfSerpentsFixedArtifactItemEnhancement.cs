namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalBrigandineArmorOfSerpentsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "30000"),
        (nameof(WeightAttribute), "-90"),
        (nameof(DexterityAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Serpents";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResConf => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResSound => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
