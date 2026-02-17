namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HobbitRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "1"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ValueAttribute), "7650"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "15"),
        (nameof(UseDeviceAttribute), "18"),
        (nameof(SavingThrowAttribute), "18"),
        (nameof(StealthAttribute), "5"),
        (nameof(SearchAttribute), "12"),
        (nameof(StrengthAttribute), "-2")
    };
}
