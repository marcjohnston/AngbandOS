namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScythePolearmWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
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
        (nameof(WeightAttribute), "250"),
        (nameof(ValueAttribute), "800"),
        (nameof(DamageDiceAttribute), "5"),
        (nameof(DiceSidesAttribute), "3"),
    };
}
