namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfBarzaiFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(ValueAttribute), "10000"),
        (nameof(AttacksAttribute), "15"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.ResistAll20p1d20Activation);
    public override string FriendlyName => "of Barzai";
    public override ColorEnum? Color => ColorEnum.Green;
}
