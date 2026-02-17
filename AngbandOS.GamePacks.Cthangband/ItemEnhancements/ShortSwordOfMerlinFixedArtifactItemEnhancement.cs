namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortSwordOfMerlinFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "7"),
        (nameof(MeleeToHitAttribute), "3"),
        (nameof(ValueAttribute), "35000"),
        (nameof(AttacksAttribute), "2"),
    };
    public override string FriendlyName => "of Merlin";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
