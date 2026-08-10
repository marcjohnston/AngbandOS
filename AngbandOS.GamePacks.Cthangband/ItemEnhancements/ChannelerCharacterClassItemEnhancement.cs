
namespace AngbandOS.GamePacks.Cthangband;

public class ChannelerCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "-1"),
        (nameof(BonusCharismaAttribute), "3"),
        (nameof(BonusConstitutionAttribute), "-1"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "0"),
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(ValueAttribute), "150"),
        (nameof(DisarmTrapsAttribute), "40"),
        (nameof(UseDeviceAttribute), "40"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(SavingThrowBonusPerLevelAttribute), "9"),
        (nameof(UseDeviceAttribute), "40"),
        (nameof(UseDeviceBonusPerLevelAttribute), "13")
    };
}
