
namespace AngbandOS.GamePacks.Cthangband;

public class WarriorCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "5"),
        (nameof(BonusCharismaAttribute), "-1"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "-2"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(ValueAttribute), "5550"),
        (nameof(DisarmTrapsAttribute), "25"),
        (nameof(UseDeviceAttribute), "18"),
        (nameof(SavingThrowAttribute), "18"),
        (nameof(SavingThrowBonusPerLevelAttribute), "10"),
        (nameof(UseDeviceAttribute), "18"),
        (nameof(UseDeviceBonusPerLevelAttribute), "7")
    };
}
