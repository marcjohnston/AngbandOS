namespace AngbandOS.GamePacks.Cthangband;
    
public class HighElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(SeeInvisAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "5"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "3"),
        (nameof(BonusDexterityAttribute), "3"),
        (nameof(ValueAttribute), "14250"),
        (nameof(InfraVisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "4"),
        (nameof(UseDeviceAttribute), "20"),
        (nameof(SavingThrowAttribute), "20"),
        (nameof(StealthAttribute), "4"),
        (nameof(SearchAttribute), "3"),
        (nameof(BonusStrengthAttribute), "1"),
        (nameof(UseDeviceAttribute), "20"),
    };
}
