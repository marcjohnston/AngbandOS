namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OrcishPickDiggingWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ShowModsAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "150"),
        (nameof(ValueAttribute), "300"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "3"),
    };
}
