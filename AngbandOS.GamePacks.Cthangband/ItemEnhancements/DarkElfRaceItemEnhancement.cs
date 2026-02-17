namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class DarkElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "5250"),
        (nameof(InfravisionAttribute), "5"),
        (nameof(DisarmTrapsAttribute), "5"),
        (nameof(UseDeviceAttribute), "15"),
        (nameof(SavingThrowAttribute), "20"),
        (nameof(StealthAttribute), "3"),
        (nameof(SearchAttribute), "8"),
        (nameof(StrengthAttribute), "-1")
    };
}
