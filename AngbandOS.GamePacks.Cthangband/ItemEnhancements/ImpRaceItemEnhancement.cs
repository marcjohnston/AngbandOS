namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ImpRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-3"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "-1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-1350"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-3"),
        (nameof(UseDeviceAttribute), "2"),
        (nameof(SavingThrowAttribute), "-1"),
        (nameof(StealthAttribute), "1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "-1"),
    };
}
