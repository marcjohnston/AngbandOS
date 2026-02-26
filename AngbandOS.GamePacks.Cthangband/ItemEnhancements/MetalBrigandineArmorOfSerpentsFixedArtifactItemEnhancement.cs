namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalBrigandineArmorOfSerpentsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
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
        (nameof(ResConfAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResSoundAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "30000"),
        (nameof(WeightAttribute), "-90"),
        (nameof(DexterityAttribute), "2"),
        (nameof(StrengthAttribute), "2"),
    };
    public override string FriendlyName => "of Serpents";
    public override ColorEnum? Color => ColorEnum.Grey;
}
