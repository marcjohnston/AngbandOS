namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DwarvenPickDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShowModsAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "600"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "4"),
    };
}
