
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChannelerCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-1"),
        (nameof(CharismaAttribute), "3"),
        (nameof(ConstitutionAttribute), "-1"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "0"),
        (nameof(DexterityAttribute), "-1"),
        (nameof(ValueAttribute), "150"),
        (nameof(DisarmTrapsAttribute), "40"),
        (nameof(UseDeviceAttribute), "40"),
        (nameof(SavingThrowAttribute), "30"),
    };
}
