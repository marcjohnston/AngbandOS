namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DraconianRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-3"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "1"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "7050"),
        (nameof(InfravisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "3"),
        (nameof(StealthAttribute), "0"),
        (nameof(SearchAttribute), "1"),
        (nameof(StrengthAttribute), "2")
    };
}
