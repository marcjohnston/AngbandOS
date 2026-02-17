namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class MindFlayerRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-3"),
        (nameof(CharismaAttribute), "-5"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "1350"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "25"),
        (nameof(SavingThrowAttribute), "15"),
        (nameof(StealthAttribute), "2"),
        (nameof(SearchAttribute), "5"),
    };
}
