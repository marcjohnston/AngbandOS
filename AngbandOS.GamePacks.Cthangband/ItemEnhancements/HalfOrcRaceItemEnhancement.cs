namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfOrcRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "600"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-3"),
        (nameof(UseDeviceAttribute), "-3"),
        (nameof(SavingThrowAttribute), "-3"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "0"),
        (nameof(StrengthAttribute), "2")
    };
}
