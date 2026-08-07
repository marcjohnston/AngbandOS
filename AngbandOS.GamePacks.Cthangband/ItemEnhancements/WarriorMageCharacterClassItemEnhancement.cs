
namespace AngbandOS.GamePacks.Cthangband;

public class WarriorMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "0"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "6450"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "28"),
    };
}
