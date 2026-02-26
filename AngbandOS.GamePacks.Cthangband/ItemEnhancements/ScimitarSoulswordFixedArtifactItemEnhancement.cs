namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScimitarSoulswordFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(AttacksAttribute), "1"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "11"),
        (nameof(MeleeToHitAttribute), "9"),
        (nameof(ValueAttribute), "111111"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
    };
    public override string FriendlyName => "'Soulsword'";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
