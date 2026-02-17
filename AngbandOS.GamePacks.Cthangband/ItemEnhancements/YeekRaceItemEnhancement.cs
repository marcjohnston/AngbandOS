namespace AngbandOS.GamePacks.Cthangband;
    
[Serializable]
public class YeekRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-2"),
        (nameof(CharismaAttribute), "-7"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "1"),
        (nameof(IntelligenceAttribute), "1"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-4350"),
        (nameof(InfravisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "2"),
        (nameof(UseDeviceAttribute), "4"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "3"),
        (nameof(SearchAttribute), "5"),
    };
}
