namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TridentOfTheGnorriFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImAcidAttribute), "true"),
        (nameof(RegenAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayAnimalAttribute), "true"),
        (nameof(SlowDigestAttribute), "true"),
        (nameof(FeatherAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.TeleportAwayEvery150DirectionalActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "19"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(DamageDiceAttribute), "3"),
        (nameof(ValueAttribute), "120000"),
        (nameof(RadiusAttribute), "3"),
        (nameof(SlayDragonAttribute), "3"),
        (nameof(DexterityAttribute), "4"),
    };
    public override string FriendlyName => "of the Gnorri";
    public override ColorEnum? Color => ColorEnum.Yellow;
}
