namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DwarfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-3"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "-2"),
        (nameof(ValueAttribute), "1050"),
        (nameof(InfravisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "2"),
        (nameof(UseDeviceAttribute), "9"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "7"),
        (nameof(StrengthAttribute), "2")
    };
}
