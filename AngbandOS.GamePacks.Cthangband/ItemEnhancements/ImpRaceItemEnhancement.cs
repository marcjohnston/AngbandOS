namespace AngbandOS.GamePacks.Cthangband;
public class ImpRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResFireAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-3"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "-1"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "-1350"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-3"),
        (nameof(SavingThrowAttribute), "-1"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(BonusStrengthAttribute), "-1"),
        (nameof(UseDeviceAttribute), "2"),
    };
}
