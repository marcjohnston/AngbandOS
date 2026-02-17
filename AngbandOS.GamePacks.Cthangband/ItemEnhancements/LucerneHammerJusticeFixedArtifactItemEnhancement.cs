namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LucerneHammerJusticeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandColdAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(RadiusAttribute), "3"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(ToDamageAttribute), "6"),
        (nameof(MeleeToHitAttribute), "10"),
        (nameof(AttacksAttribute), "8"),
        (nameof(ValueAttribute), "30000"),
        (nameof(WisdomAttribute), "4"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife90Every70DirectionalActivation);
    public override string FriendlyName => "'Justice'";
    public override ColorEnum? Color => ColorEnum.BrightBlue;
}
