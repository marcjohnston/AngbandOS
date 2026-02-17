
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "1"),
        (nameof(IntelligenceAttribute), "-3"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "4500"),
        (nameof(DisarmTrapsAttribute), "20"),
        (nameof(UseDeviceAttribute), "24"),
        (nameof(SavingThrowAttribute), "26"),
    };
}
