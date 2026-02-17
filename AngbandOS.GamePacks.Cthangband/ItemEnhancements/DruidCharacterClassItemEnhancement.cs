
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DruidCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "3"),
        (nameof(ConstitutionAttribute), "0"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "-3"),
        (nameof(DexterityAttribute), "-2"),
        (nameof(ValueAttribute), "-1050"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "32"),
        (nameof(StrengthAttribute), "-1")
    };
}
