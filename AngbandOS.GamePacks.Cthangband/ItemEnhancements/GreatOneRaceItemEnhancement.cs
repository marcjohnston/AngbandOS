namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class GreatOneRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "3"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
        (nameof(DexterityAttribute), "2"),
        (nameof(ValueAttribute), "12900"),
        (nameof(DisarmTrapsAttribute), "4"),
        (nameof(UseDeviceAttribute), "5"),
        (nameof(SavingThrowAttribute), "5"),
        (nameof(StealthAttribute), "2"),
        (nameof(SearchAttribute), "3"),
        (nameof(StrengthAttribute), "1")
    };
}
