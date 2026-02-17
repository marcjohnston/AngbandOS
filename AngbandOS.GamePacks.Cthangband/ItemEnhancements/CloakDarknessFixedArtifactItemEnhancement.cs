namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakDarknessFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.SleepActivation);
    public override string FriendlyName => "'Darkness'";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StealthAttribute), "2"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "13000"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(AttacksAttribute), "4"),
    };
    public override ColorEnum? Color => ColorEnum.Green;
}
