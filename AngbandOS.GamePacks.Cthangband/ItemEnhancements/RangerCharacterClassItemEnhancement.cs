
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RangerCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "7650"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "32"),
        (nameof(SavingThrowAttribute), "28"),
    };
}
