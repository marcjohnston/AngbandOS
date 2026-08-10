namespace AngbandOS.GamePacks.Cthangband;
    
public class YeekRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResAcidAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "-2"),
        (nameof(BonusCharismaAttribute), "-7"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "-4350"),
        (nameof(InfraVisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "2"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "3"),
        (nameof(SearchAttribute), "5"),
        (nameof(UseDeviceAttribute), "4"),
    };
}
