
namespace AngbandOS.GamePacks.Cthangband;

public class RogueCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "-1"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "-2"),
        (nameof(BonusIntelligenceAttribute), "1"),
        (nameof(BonusDexterityAttribute), "3"),
        (nameof(ValueAttribute), "5550"),
        (nameof(DisarmTrapsAttribute), "45"),
        (nameof(UseDeviceAttribute), "32"),
        (nameof(SavingThrowAttribute), "28"),
    };
}
