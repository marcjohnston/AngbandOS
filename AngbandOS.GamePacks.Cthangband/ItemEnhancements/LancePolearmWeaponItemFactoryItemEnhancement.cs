namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LancePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(CanApplyBlessedArtifactBiasAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "300"),
        (nameof(ValueAttribute), "230"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "8"),
    };
}
