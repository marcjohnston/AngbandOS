namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordOfTheDawnFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
    };

    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandFireAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResBlindAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
        (nameof(SustChaAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.SummonFriendlyReaverEvery500p1d500Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "20"),
        (nameof(MeleeToHitAttribute), "20"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "250000"),
        (nameof(VorpalExtraAttacks1InChanceAttribute), "2"),
        (nameof(Vorpal1InChanceAttribute), "6"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(CharismaAttribute), "3"),
        (nameof(RadiusAttribute), "3"),
    };
    public override string FriendlyName => "of the Dawn";
}
