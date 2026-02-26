namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallMetalShieldVitriolFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FreeActAttribute), "true"),
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ImAcidAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResSoundAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "25"),
        (nameof(ValueAttribute), "60000"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(StrengthAttribute), "4"),
    };
    public override string FriendlyName => "'Vitriol'";
}
