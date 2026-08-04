namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScimitarWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(CanApplyBlessedArtifactBiasAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "130"),
        (nameof(ValueAttribute), "250"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "5"),
    };
}
