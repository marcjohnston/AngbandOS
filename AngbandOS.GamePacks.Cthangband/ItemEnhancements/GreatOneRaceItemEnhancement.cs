namespace AngbandOS.GamePacks.Cthangband;
public class GreatOneRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SustConAttribute), "true"),
        (nameof(RegenAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "3"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(ValueAttribute), "12900"),
        (nameof(DisarmTrapsAttribute), "4"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "5"),
        (nameof(StealthAttribute), "2"),
        (nameof(SearchAttribute), "3"),
        (nameof(BonusStrengthAttribute), "1"),
        (nameof(UseDeviceAttribute), "5"),
    };
}
