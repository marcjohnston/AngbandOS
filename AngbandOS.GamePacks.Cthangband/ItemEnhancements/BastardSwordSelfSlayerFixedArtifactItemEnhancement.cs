namespace AngbandOS.GamePacks.Cthangband;

public class BastardSwordSelfSlayerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayDemonAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(SlayDragonAttribute), "5"),
        (nameof(BonusConstitutionAttribute), "5"),
        (nameof(ValueAttribute), "100000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(MeleeToHitAttribute), "-20"),
        (nameof(ToDamageAttribute), "20"),
    };
    public override string FriendlyName => "'Selfslayer'";
}
