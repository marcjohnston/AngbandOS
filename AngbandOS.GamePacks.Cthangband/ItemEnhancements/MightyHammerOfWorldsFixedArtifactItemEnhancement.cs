namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MightyHammerOfWorldsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImpactAttribute), "true"),
        (nameof(NoMagicAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "25"),
        (nameof(MeleeToHitAttribute), "5"),
        (nameof(AttacksAttribute), "10"),
        (nameof(DamageDiceAttribute), "6"),
        (nameof(ValueAttribute), "500000"),
        (nameof(WeightAttribute), "800"),
        (nameof(SlayDragonAttribute), "5"),
    };
    public override string FriendlyName => "of Worlds";
    public override ColorEnum? Color => ColorEnum.Black;
}
