
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-1"),
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "0"),
        (nameof(WisdomAttribute), "3"),
        (nameof(IntelligenceAttribute), "-3"),
        (nameof(DexterityAttribute), "-1"),
        (nameof(ValueAttribute), "-1500"),
        (nameof(DisarmTrapsAttribute), "25"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "32"),
    };
}
