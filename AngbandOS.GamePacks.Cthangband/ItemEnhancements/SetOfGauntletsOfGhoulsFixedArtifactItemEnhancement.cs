namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsOfGhoulsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(RegenAttribute), "true"),
    };

    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(SustConAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "33000"),
        (nameof(ConstitutionAttribute), "4"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfFrost6d8Every1d7p7DirectionalActivation);
    public override string FriendlyName => "of Ghouls";
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
