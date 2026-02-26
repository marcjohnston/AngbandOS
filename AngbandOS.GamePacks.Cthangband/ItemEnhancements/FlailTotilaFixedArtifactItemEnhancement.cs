namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlailTotilaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.ConfuseMonster20Every15DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "55000"),
        (nameof(StealthAttribute), "2"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "'Totila'";
}
