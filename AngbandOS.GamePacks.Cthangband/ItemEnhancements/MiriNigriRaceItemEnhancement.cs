namespace AngbandOS.GamePacks.Cthangband;
public class MiriNigriRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResConfAttribute), "true"),
        (nameof(ResSoundAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "-4"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "-1"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(ValueAttribute), "-1800"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-2"),
        (nameof(SavingThrowAttribute), "-1"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(UseDeviceAttribute), "-2"),
    };
}
