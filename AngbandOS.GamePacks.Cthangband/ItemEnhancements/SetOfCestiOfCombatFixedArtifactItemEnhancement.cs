namespace AngbandOS.GamePacks.Cthangband;

public class SetOfCestiOfCombatFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.MagicalArrow150Every1d90p90DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "10"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "110000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(DexterityAttribute), "4"),
    };
    public override string FriendlyName => "of Combat";
}
