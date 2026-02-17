
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FanaticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "6300"),
        (nameof(DisarmTrapsAttribute), "20"),
        (nameof(UseDeviceAttribute), "24"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(StrengthAttribute), "2")
    };
}
