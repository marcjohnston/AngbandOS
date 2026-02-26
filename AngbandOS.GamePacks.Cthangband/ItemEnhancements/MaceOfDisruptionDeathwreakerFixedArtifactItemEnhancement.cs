namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MaceOfDisruptionDeathwreakerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(BrandPoisAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImFireAttribute), "true"),
        (nameof(NoTeleAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
        (nameof(VampiricAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "18"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(ValueAttribute), "444444"),
        (nameof(WeightAttribute), "280"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(TunnelAttribute), "6"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "6"),
    };
    public override string FriendlyName => "'Deathwreaker'";
}
