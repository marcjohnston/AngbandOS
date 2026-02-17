
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MysticCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "0"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "8400"),
        (nameof(DisarmTrapsAttribute), "40"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "30"),
    };
}
