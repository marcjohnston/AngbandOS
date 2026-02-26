namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BroadSwordLightningFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BrandElecAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFearAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
    };
    public override string FriendlyName => "'Lightning'";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(SlayDragonAttribute), "15"),
        (nameof(RadiusAttribute), "3"),
        (nameof(ValueAttribute), "95000"),
        (nameof(SearchAttribute), "4"),
        (nameof(MeleeToHitAttribute), "12"),
        (nameof(ToDamageAttribute), "16"),
    };
}
