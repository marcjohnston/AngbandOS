namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletOfLobonFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.ProtectionFromEvilActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "60000"),
        (nameof(ConstitutionAttribute), "2"),
    };
    public override string FriendlyName => "of Lobon";
}
