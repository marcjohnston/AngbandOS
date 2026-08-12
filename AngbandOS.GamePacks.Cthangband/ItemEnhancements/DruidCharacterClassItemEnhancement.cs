
namespace AngbandOS.GamePacks.Cthangband;

public class DruidCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "3"),
        (nameof(BonusConstitutionAttribute), "0"),
        (nameof(BonusWisdomAttribute), "4"),
        (nameof(BonusIntelligenceAttribute), "-3"),
        (nameof(BonusDexterityAttribute), "-2"),
        (nameof(BonusStrengthAttribute), "-1"),
        (nameof(ValueAttribute), "-1050"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(SavingThrowAttribute), "32"),
        (nameof(SavingThrowBonusPerLevelAttribute), "12"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(UseDeviceBonusPerLevelAttribute), "10"),
        (nameof(SearchAttribute), "20"),
        (nameof(StealthAttribute), "4")
    };
}
