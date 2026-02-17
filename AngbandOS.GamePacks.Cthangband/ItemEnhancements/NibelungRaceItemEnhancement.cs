namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class NibelungRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "1"),
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "3000"),
        (nameof(InfravisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "3"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "5"),
    };
}
