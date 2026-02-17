namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GnomeRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-2"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "3900"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "12"),
        (nameof(SavingThrowAttribute), "12"),
        (nameof(StealthAttribute), "3"),
        (nameof(SearchAttribute), "6"),
        (nameof(StrengthAttribute), "-1")
    };
}
