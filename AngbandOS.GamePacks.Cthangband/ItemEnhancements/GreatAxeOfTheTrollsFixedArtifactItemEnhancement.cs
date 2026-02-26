namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatAxeOfTheTrollsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(BlessedAttribute), "true"),
        (nameof(BrandColdAttribute), "true"),
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImColdAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayEvilAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayUndeadAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.MassCarnageActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ToDamageAttribute), "18"),
        (nameof(MeleeToHitAttribute), "15"),
        (nameof(AttacksAttribute), "8"),
        (nameof(ValueAttribute), "200000"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(CharismaAttribute), "2"),
        (nameof(StrengthAttribute), "2")
    };
    public override string FriendlyName => "of the Trolls";
}
