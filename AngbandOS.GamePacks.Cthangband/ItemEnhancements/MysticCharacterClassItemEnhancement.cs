
namespace AngbandOS.GamePacks.Cthangband;

public class MysticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "2"),
        (nameof(BonusCharismaAttribute), "0"),
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(BonusWisdomAttribute), "2"),
        (nameof(BonusIntelligenceAttribute), "-1"),
        (nameof(BonusDexterityAttribute), "2"),
        (nameof(ValueAttribute), "8400"),
        (nameof(DisarmTrapsAttribute), "40"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(SavingThrowPerLevelAttribute), "11"),
    };
}
