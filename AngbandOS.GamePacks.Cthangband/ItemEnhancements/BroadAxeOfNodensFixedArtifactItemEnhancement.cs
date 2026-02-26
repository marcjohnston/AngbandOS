namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadAxeOfNodensFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(ValueAttribute), "50000"),
        (nameof(MeleeToHitAttribute), "13"),
        (nameof(ToDamageAttribute), "19"),
    };
    public override string FriendlyName => "of Nodens";
    public override ColorEnum? Color => ColorEnum.Grey;
}
