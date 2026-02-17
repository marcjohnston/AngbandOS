namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class KlackonRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "2700"),
        (nameof(InfravisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "5"),
        (nameof(StealthAttribute), "0"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "2"),
    };
}
