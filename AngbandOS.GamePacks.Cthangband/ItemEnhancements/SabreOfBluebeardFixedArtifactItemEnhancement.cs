namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreOfBluebeardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "8"),
        (nameof(MeleeToHitAttribute), "6"),
        (nameof(ValueAttribute), "25000"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(AttacksAttribute), "1"),
    };
    public override string FriendlyName => "of Bluebeard";
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
