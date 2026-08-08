
namespace AngbandOS.GamePacks.Cthangband;

public class PaladinCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "3"),
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "1"),
        (nameof(BonusIntelligenceAttribute), "-3"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "4500"),
        (nameof(DisarmTrapsAttribute), "20"),
        (nameof(UseDeviceAttribute), "24"),
        (nameof(SavingThrowAttribute), "26"),
        (nameof(SavingThrowPerLevelAttribute), "11"),
    };
}
