namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MiriNigriRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "-1"),
        (nameof(ValueAttribute), "-1800"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-2"),
        (nameof(SavingThrowAttribute), "-1"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
    };
}
