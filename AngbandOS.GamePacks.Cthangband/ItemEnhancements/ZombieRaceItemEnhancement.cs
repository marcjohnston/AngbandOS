namespace AngbandOS.GamePacks.Cthangband;
public class ZombieRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResNetherAttribute), "true"),
        (nameof(HoldLifeAttribute), "true"),
        (nameof(SeeInvisAttribute), "true"),
        (nameof(ResPoisAttribute), "true"),
        (nameof(SlowDigestAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "-5"),
        (nameof(BonusConstitutionAttribute), "4"),
        (nameof(BonusWisdomAttribute), "-6"),
        (nameof(BonusIntelligenceAttribute), "-6"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "-8250"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "8"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(UseDeviceAttribute), "-5"),
    };
}
