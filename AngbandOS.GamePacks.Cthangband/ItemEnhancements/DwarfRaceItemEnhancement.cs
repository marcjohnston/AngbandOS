namespace AngbandOS.GamePacks.Cthangband;
public class DwarfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResBlindAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-3"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "-2"),
        (nameof(ValueAttribute), "1050"),
        (nameof(InfraVisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "2"),
        (nameof(UseDeviceAttribute), "9"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "7"),
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(UseDeviceAttribute), "9"),
    };
}
