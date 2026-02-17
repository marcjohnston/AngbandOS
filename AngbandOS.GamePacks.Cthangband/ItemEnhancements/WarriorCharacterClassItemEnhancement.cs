
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarriorCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "5"),
        (nameof(CharismaAttribute), "-1"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-2"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "5550"),
        (nameof(DisarmTrapsAttribute), "25"),
        (nameof(UseDeviceAttribute), "18"),
        (nameof(SavingThrowAttribute), "18"),
    };
}
