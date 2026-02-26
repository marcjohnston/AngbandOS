namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeLeatherShieldRawhideFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResLightAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "20"),
        (nameof(ValueAttribute), "12000"),
        (nameof(WeightAttribute), "-40"),
    };
    public override string FriendlyName => "'Rawhide'";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
