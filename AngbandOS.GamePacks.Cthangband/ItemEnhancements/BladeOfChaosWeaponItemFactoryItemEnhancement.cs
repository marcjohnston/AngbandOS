namespace AngbandOS.GamePacks.Cthangband;

public class BladeOfChaosWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(HatesAcidAttribute), "true"),
        (nameof(ChaoticAttribute), "true"),
        (nameof(ResChaosAttribute), "true"),
        (nameof(ResConfAttribute), "true"),
        (nameof(ShowModsAttribute), "true"),
        (nameof(CanApplyBlessedArtifactBiasAttribute), "true"),
        (nameof(CanApplySlayingBonusAttribute), "true"),
        (nameof(CanApplyBonusArmorClassMiscPowerAttribute), "true"),
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "180"),
        (nameof(ValueAttribute), "4000"),
        (nameof(DamageDiceAttribute), "6"),
        (nameof(DiceSidesAttribute), "5"),
    };
}
