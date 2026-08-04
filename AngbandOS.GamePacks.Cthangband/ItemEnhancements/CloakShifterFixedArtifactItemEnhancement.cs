namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakShifterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(StealthAttribute), "3"),
        (nameof(ValueAttribute), "11000"),
        (nameof(AttacksAttribute), "15"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Teleport100Every45Activation);
    public override string FriendlyName => "'Shifter'";
}
