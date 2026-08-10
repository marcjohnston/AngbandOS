
namespace AngbandOS.GamePacks.Cthangband;

public class ChosenOneCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "3"),
        (nameof(BonusCharismaAttribute), "-1"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "-2"),
        (nameof(BonusIntelligenceAttribute), "-2"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(ValueAttribute), "3150"),
        (nameof(DisarmTrapsAttribute), "25"),
        (nameof(SavingThrowAttribute), "20"),
        (nameof(SavingThrowBonusPerLevelAttribute), "10"),
        (nameof(UseDeviceAttribute), "18"),
        (nameof(UseDeviceBonusPerLevelAttribute), "13")
    };
}
