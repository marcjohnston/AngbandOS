namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HalfGiantRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-3"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "-2"),
        (nameof(IntelligenceAttribute), "-2"),
        (nameof(DexterityAttribute), "-2"),
        (nameof(ValueAttribute), "-150"),
        (nameof(InfravisionAttribute), "3"),
        (nameof(DisarmTrapsAttribute), "-6"),
        (nameof(UseDeviceAttribute), "-8"),
        (nameof(SavingThrowAttribute), "-6"),
        (nameof(StealthAttribute), "-2"),
        (nameof(SearchAttribute), "-1"),
        (nameof(StrengthAttribute), "4")
    };
}
