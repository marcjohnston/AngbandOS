namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TwoHandedSwordFiretongueFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "21"),
        (nameof(MeleeToHitAttribute), "19"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "205000"),
        (nameof(WeightAttribute), "50"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(CharismaAttribute), "4"),
        (nameof(RadiusAttribute), "3"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "'Firetongue'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
