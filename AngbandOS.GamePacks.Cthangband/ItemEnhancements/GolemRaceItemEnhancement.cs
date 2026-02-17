namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GolemRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-4"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(WisdomAttribute), "-5"),
        (nameof(IntelligenceAttribute), "-5"),
        (nameof(DexterityAttribute), "0"),
        (nameof(ValueAttribute), "-4200"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "4")
    };
}
