namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailOfTheOgreLordsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(AttacksAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(ValueAttribute), "40000"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(WisdomAttribute), "3"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DestroyDoorsEvery10Activation);
    public override string FriendlyName => "of the Ogre Lords";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResConf => true;
    public override bool? ResPois => true;
    public override ColorEnum? Color => ColorEnum.Grey;
}
