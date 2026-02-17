namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfTheSwashbucklerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
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
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(CharismaAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ValueAttribute), "35000"),
        (nameof(AttacksAttribute), "18"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.RechargeActivation);
    public override string FriendlyName => "of the Swashbuckler";
    public override ColorEnum? Color => ColorEnum.Green;
}
