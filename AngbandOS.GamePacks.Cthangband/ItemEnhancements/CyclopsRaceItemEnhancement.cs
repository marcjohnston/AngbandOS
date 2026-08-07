namespace AngbandOS.GamePacks.Cthangband;
public class CyclopsRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResSoundAttribute), "true")
    };

    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-6"),
        (nameof(BonusConstitutionAttribute), "4"),
        (nameof(BonusWisdomAttribute), "-3"),
        (nameof(BonusIntelligenceAttribute), "-3"),
        (nameof(BonusDexterityAttribute), "-3"),
        (nameof(ValueAttribute), "-3900"),
        (nameof(InfraVisionAttribute), "1"),
        (nameof(DisarmTrapsAttribute), "-4"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "-5"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-2"),
        (nameof(BonusStrengthAttribute), "4")
    };
}
