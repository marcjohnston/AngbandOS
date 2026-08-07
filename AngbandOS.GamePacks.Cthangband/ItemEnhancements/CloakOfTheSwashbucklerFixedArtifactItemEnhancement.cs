namespace AngbandOS.GamePacks.Cthangband;

public class CloakOfTheSwashbucklerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(BonusCharismaAttribute), "3"),
        (nameof(BonusDexterityAttribute), "3"),
        (nameof(ValueAttribute), "35000"),
        (nameof(AttacksAttribute), "18"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RechargeActivation);
    public override string FriendlyName => "of the Swashbuckler";
}
