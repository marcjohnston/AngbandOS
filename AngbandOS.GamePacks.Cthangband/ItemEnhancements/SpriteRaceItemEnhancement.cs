namespace AngbandOS.GamePacks.Cthangband;
public class SpriteRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(FeatherAttribute), "true"),
        (nameof(ResLightAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(GlowRadiusAttribute), "1"),
        (nameof(SpeedAttribute), "X/10"),
        (nameof(BonusStrengthAttribute), "-4"),
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "3"),
        (nameof(BonusIntelligenceAttribute), "3"),
        (nameof(BonusDexterityAttribute), "3"),
        (nameof(ValueAttribute), "4500"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "10"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "4"),
        (nameof(SearchAttribute), "10"),
    };
}
