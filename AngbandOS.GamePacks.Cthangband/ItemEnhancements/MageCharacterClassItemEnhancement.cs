
namespace AngbandOS.GamePacks.Cthangband;

public class MageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-3150"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "36"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(StrengthAttribute), "-5"),
    };
}
