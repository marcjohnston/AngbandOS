
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RogueCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "-1"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "-2"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ValueAttribute), "5550"),
        (nameof(DisarmTrapsAttribute), "45"),
        (nameof(UseDeviceAttribute), "32"),
        (nameof(SavingThrowAttribute), "28"),
    };
}
