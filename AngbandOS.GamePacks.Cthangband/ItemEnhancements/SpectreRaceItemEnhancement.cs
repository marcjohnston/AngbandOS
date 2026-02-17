namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpectreRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-5"),
        (nameof(CharismaAttribute), "-6"),
        (nameof(ConstitutionAttribute), "-3"),
        (nameof(WisdomAttribute), "4"),
        (nameof(IntelligenceAttribute), "4"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "-300"),
        (nameof(InfravisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "25"),
        (nameof(SavingThrowAttribute), "20"),
        (nameof(StealthAttribute), "5"),
        (nameof(SearchAttribute), "5"),
    };
}
