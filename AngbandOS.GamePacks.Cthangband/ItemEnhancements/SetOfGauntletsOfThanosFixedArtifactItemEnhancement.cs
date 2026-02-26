namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfThanosFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(AggravateAttribute), "true"),
        (nameof(DreadCurseAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImColdAttribute), "true"),
        (nameof(ImFireAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(TeleportAttribute), "true"),
    };
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ToDamageAttribute), "-12"),
        (nameof(MeleeToHitAttribute), "-11"),
        (nameof(ValueAttribute), "40000"),
        (nameof(DexterityAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Thanos";
}
