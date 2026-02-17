
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindcrafterCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "-1"),
        (nameof(WisdomAttribute), "3"),
        (nameof(IntelligenceAttribute), "0"),
        (nameof(DexterityAttribute), "-1"),
        (nameof(ValueAttribute), "900"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "30"),
        (nameof(StrengthAttribute), "-1"),
    };
}
