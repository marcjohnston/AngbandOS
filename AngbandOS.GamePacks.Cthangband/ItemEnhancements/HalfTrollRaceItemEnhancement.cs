namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTrollRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-6"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "-4"),
        (nameof(DexterityAttribute), "-4"),
        (nameof(ValueAttribute), "-1500"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-8"),
        (nameof(SavingThrowAttribute), "-8"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "4")
    };
}
