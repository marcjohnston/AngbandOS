
namespace AngbandOS.GamePacks.Cthangband;

public class CultistCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "4"),
        (nameof(BonusDexterityAttribute), "1"),
        (nameof(BonusStrengthAttribute), "-5"),
        (nameof(ValueAttribute), "-3300"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "36"),
        (nameof(SavingThrowAttribute), "32"),
        (nameof(SavingThrowPerLevelAttribute), "10"),
    };
}
