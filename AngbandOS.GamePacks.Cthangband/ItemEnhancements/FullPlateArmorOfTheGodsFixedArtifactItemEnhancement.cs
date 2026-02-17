namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FullPlateArmorOfTheGodsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "50000"),
        (nameof(WeightAttribute), "-80"),
        (nameof(ConstitutionAttribute), "1"),
    };
    public override string FriendlyName => "of the Gods";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResConf => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? ResNexus => true;
    public override bool? ResSound => true;
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
