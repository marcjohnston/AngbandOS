namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SkeletonRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "0"),
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "-2"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "-5400"),
        (nameof(InfravisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "5"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
    };
}
