
namespace AngbandOS.GamePacks.Cthangband;

public class MageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "3"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(BonusStrengthAttribute), "-5"),
        (nameof(ValueAttribute), "-3150"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "36"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(SavingThrowBonusPerLevelAttribute), "9"),
        (nameof(UseDeviceAttribute), "36"),
        (nameof(UseDeviceBonusPerLevelAttribute), "13")
    };
}
