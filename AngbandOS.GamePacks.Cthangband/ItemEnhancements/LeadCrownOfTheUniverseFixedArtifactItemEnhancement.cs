namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeadCrownOfTheUniverseFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(NoTeleAttribute), "true"),
        (nameof(PermaCurseAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(TelepathyAttribute), "true"),
    };
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HeavyCurseAttribute), "true"),
        (nameof(IsCursedAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "10000000"),
        (nameof(WisdomAttribute), "125"),
        (nameof(InfravisionAttribute), "125"),
        (nameof(IntelligenceAttribute), "125"),
        (nameof(DexterityAttribute), "125"),
        (nameof(ConstitutionAttribute), "125"),
        (nameof(CharismaAttribute), "125"),
        (nameof(RadiusAttribute), "3"),
        (nameof(StrengthAttribute), "125"),
    };
    public override string FriendlyName => "of the Universe";
    public override ColorEnum? Color => ColorEnum.Black;
}
