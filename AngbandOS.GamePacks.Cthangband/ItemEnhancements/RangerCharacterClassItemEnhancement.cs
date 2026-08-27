
namespace AngbandOS.GamePacks.Cthangband;

public class RangerCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "1"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "2"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(ValueAttribute), "7650"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(SavingThrowAttribute), "28"),
        (nameof(SavingThrowBonusPerLevelAttribute), "10"),
        (nameof(UseDeviceAttribute), "32"),
        (nameof(UseDeviceBonusPerLevelAttribute), "10"),
        (nameof(SearchAttribute), "24"),
        (nameof(StealthAttribute), "4")
    };
}
