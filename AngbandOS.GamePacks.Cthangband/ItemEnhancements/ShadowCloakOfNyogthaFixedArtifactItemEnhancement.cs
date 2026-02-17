namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfNyogthaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "55000"),
        (nameof(WisdomAttribute), "2"),
        (nameof(StealthAttribute), "2"),
        (nameof(SpeedAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(CharismaAttribute), "2"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RestoreLifeLevelsEvery450DirectionalActivation);
    public override string FriendlyName => "of Nyogtha";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResFire => true;
    public override ColorEnum? Color => ColorEnum.Black;
}
