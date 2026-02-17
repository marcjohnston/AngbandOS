namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChainMailHeartguardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(ResShardsAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(CharismaAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
        (nameof(ValueAttribute), "32000"),
        (nameof(AttacksAttribute), "15"),
        (nameof(MeleeToHitAttribute), "-2"),
    };
    public override string FriendlyName => "'Heartguard'";
    public override ColorEnum? Color => ColorEnum.Grey;
}
