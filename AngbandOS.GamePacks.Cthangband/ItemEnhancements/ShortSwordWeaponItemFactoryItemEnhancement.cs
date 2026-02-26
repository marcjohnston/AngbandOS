namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortSwordWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(CanApplyBlessedArtifactBiasAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "80"),
        (nameof(ValueAttribute), "90"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "7"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
}
