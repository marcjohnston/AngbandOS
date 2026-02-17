namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfTitanRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "1"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "-2"),
        (nameof(ValueAttribute), "10050"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "2"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "1"),
        (nameof(StrengthAttribute), "5")
    };
}
