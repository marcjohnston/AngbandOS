namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class TchoTchoRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "3"),
        (nameof(CharismaAttribute), "-2"),
        (nameof(ConstitutionAttribute), "2"),
        (nameof(WisdomAttribute), "-1"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "2700"),
        (nameof(DisarmTrapsAttribute), "-2"),
        (nameof(UseDeviceAttribute), "-10"),
        (nameof(SavingThrowAttribute), "2"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "1"),
    };
}
