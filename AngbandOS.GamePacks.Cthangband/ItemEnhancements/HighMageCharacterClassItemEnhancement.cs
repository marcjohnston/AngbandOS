
namespace AngbandOS.GamePacks.Cthangband;

public class HighMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "1"),
        (nameof(BonusConstitutionAttribute), "-2"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "4"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(ValueAttribute), "-3150"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "38"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(BonusStrengthAttribute), "-5")
    };
}
