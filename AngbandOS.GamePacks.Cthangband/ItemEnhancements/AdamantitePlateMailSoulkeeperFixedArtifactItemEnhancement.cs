namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AdamantitePlateMailSoulkeeperFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HoldLifeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResNetherAttribute), "true"),
        (nameof(ResNexusAttribute), "true"),
        (nameof(SustConAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Heal1000Every888Activation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "280000"),        (nameof(AttacksAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-4"),
        (nameof(ConstitutionAttribute), "2"),
    };
    public override string FriendlyName => "'Soulkeeper'";
    public override ColorEnum? Color => ColorEnum.BrightGreen;
}
