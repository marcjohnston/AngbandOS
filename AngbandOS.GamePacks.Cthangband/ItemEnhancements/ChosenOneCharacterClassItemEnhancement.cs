
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(CharismaAttribute), "-1"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-2"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "3150"),
        (nameof(DisarmTrapsAttribute), "25"),
        (nameof(UseDeviceAttribute), "18"),
        (nameof(SavingThrowAttribute), "20"),
    };
}
