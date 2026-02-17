
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-2"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-3300"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "36"),
        (nameof(SavingThrowAttribute), "32"),
        (nameof(StrengthAttribute), "-5")
    };
}
