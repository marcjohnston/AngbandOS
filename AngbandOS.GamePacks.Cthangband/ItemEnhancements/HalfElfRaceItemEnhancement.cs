namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "-1"),
        (nameof(WisdomAttribute), "1"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "1650"),
        (nameof(InfravisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "2"),
        (nameof(UseDeviceAttribute), "3"),
        (nameof(SavingThrowAttribute), "3"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "6"),
        (nameof(StrengthAttribute), "-1")
    };
}
