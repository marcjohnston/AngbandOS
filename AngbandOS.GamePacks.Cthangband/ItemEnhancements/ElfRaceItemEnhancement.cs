namespace AngbandOS.GamePacks.Cthangband;
public class ElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResLightAttribute), "true")
    };
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "3300"),
        (nameof(InfraVisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "5"),
        (nameof(UseDeviceAttribute), "6"),
        (nameof(SavingThrowAttribute), "6"),
        (nameof(StealthAttribute), "2"),
        (nameof(SearchAttribute), "8"),
        (nameof(BonusStrengthAttribute), "-1"),
        (nameof(UseDeviceAttribute), "6"),
    };
}
