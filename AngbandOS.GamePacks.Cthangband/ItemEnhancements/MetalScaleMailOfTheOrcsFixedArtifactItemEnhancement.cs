namespace AngbandOS.GamePacks.Cthangband;

public class MetalScaleMailOfTheOrcsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ResAcidAttribute), "true"),
        (nameof(ResColdAttribute), "true"),
        (nameof(ResDarkAttribute), "true"),
        (nameof(ResDisenAttribute), "true"),
        (nameof(ResElecAttribute), "true"),
        (nameof(ResFireAttribute), "true"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.GenocideEvery500Activation);
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusArmorClassAttribute), "2"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "-2"),
        (nameof(AttacksAttribute), "40"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(ValueAttribute), "150000"),
        (nameof(BonusCharismaAttribute), "4"),
        (nameof(BonusStrengthAttribute), "4"),
    };
    public override string FriendlyName => "of the Orcs";
}
