namespace AngbandOS.GamePacks.Cthangband;

public class BattleAxeSpleenSlicerFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HideTypeAttribute), "true"),
        (nameof(IgnoreAcidAttribute), "true"),
        (nameof(IgnoreColdAttribute), "true"),
        (nameof(IgnoreElecAttribute), "true"),
        (nameof(IgnoreFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(SlayOrcAttribute), "true"),
        (nameof(SlayTrollAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(MeleeToHitAttribute), "4"),
        (nameof(ToDamageAttribute), "3"),
        (nameof(ValueAttribute), "21000"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(BonusStrengthAttribute), "1"),
        (nameof(BonusDexterityAttribute), "1"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.Heal4d8AndWoundsEvery3p1d3Activation);
    public override string FriendlyName => "'Spleen Slicer'";
}
