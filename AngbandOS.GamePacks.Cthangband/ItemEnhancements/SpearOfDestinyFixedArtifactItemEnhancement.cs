namespace AngbandOS.GamePacks.Cthangband;

public class SpearOfDestinyFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(BrandFireAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayGiantAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.StoneToMudDirectionalActivation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "15"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(ValueAttribute), "77777"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(GlowRadiusAttribute), "3"),
    };
    public override string FriendlyName => "of Destiny";
}
