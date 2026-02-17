namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsIronfistFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "15000"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfFire9d8Every1d8p8DirectionalActivation);
    public override string FriendlyName => "'Ironfist'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
