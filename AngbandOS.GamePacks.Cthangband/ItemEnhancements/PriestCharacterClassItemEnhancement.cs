
namespace AngbandOS.GamePacks.Cthangband;

public class PriestCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "-1"),
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "0"),
        (nameof(BonusWisdomAttribute), "3"),
        (nameof(BonusIntelligenceAttribute), "-3"),
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(ValueAttribute), "-1500"),
        (nameof(DisarmTrapsAttribute), "25"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "32"),
        (nameof(SavingThrowBonusPerLevelAttribute), "12"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(UseDeviceBonusPerLevelAttribute), "10")
    };
}
