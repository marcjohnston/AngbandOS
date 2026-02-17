namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class CyclopsRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-6"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(WisdomAttribute), "-3"),
        (nameof(IntelligenceAttribute), "-3"),
        (nameof(DexterityAttribute), "-3"),
        (nameof(ValueAttribute), "-3900"),
        (nameof(InfravisionAttribute), "1"),
        (nameof(DisarmTrapsAttribute), "-4"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "-5"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-2"),
        (nameof(StrengthAttribute), "4")
    };
}
