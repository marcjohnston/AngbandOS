
namespace AngbandOS.GamePacks.Cthangband;

public class MonkCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "3"),
        (nameof(ValueAttribute), "8850"),
        (nameof(DisarmTrapsAttribute), "45"),
        (nameof(SavingThrowAttribute), "28"),
        (nameof(SavingThrowBonusPerLevelAttribute), "10"),
        (nameof(UseDeviceAttribute), "32"),
        (nameof(UseDeviceBonusPerLevelAttribute), "12")
    };
}
