namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonHelmOfPowerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResBlindAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "4"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "300000"),
        (nameof(WeightAttribute), "25"),
        (nameof(DexterityAttribute), "4"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
        (nameof(TreasureRatingAttribute), "20"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Terror40xEvery3xp10Activation);
    public override string FriendlyName => "of Power";
}
