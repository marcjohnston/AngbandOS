namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShortBowRangedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(HatesFireAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(ArtifactBiasCanSlayAttribute), "true"),
        (nameof(CanApplyBlowsBonusAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "30"),
        (nameof(ValueAttribute), "50"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
