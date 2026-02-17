namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PairOfHardLeatherBootsOfIthaquaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.Speed20p1d20Every200Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "300000"),
        (nameof(SpeedAttribute), "15"),
    };
    public override string FriendlyName => "of Ithaqua";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResNexus => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
