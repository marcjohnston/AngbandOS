namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class ZombieRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "2"),
        (nameof(CharismaAttribute), "-5"),
        (nameof(ConstitutionAttribute), "4"),
        (nameof(WisdomAttribute), "-6"),
        (nameof(IntelligenceAttribute), "-6"),
        (nameof(DexterityAttribute), "1"),
        (nameof(ValueAttribute), "-8250"),
        (nameof(InfravisionAttribute), "2"),
        (nameof(DisarmTrapsAttribute), "-5"),
        (nameof(UseDeviceAttribute), "-5"),
        (nameof(SavingThrowAttribute), "8"),
        (nameof(StealthAttribute), "-1"),
        (nameof(SearchAttribute), "-1"),
    };
}
