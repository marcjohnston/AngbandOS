namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BladeOfChaosDoomcallerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(BrandColdAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(BrandPoisAttribute), "true"),
        (nameof(ChaoticAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(ValueAttribute), "250000"),
        (nameof(AttacksAttribute), "-50"),
        (nameof(MeleeToHitAttribute), "18"),
        (nameof(ToDamageAttribute), "28"),
        (nameof(RadiusAttribute), "1"),
    };
    public override string FriendlyName => "'Doomcaller'";
}
