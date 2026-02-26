namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfNyogthaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
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
    public override ColorEnum? Color => ColorEnum.Black;
}
