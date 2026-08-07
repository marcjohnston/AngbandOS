
namespace AngbandOS.GamePacks.Cthangband;

public class MindcrafterCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "2"),
        (nameof(BonusConstitutionAttribute), "-1"),
        (nameof(BonusWisdomAttribute), "3"),
        (nameof(BonusIntelligenceAttribute), "0"),
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(ValueAttribute), "900"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(BonusStrengthAttribute), "-1"),
    };
}
