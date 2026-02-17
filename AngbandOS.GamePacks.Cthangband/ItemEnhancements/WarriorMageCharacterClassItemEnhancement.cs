
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorMageCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "0"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "6450"),
        (nameof(DisarmTrapsAttribute), "30"),
        (nameof(UseDeviceAttribute), "30"),
        (nameof(SavingThrowAttribute), "28"),
    };
}
