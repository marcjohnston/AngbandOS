namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class HumanRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "0"),
        (nameof(CharismaAttribute), "0"),
        (nameof(ConstitutionAttribute), "0"),
        (nameof(WisdomAttribute), "0"),
        (nameof(IntelligenceAttribute), "0"),
        (nameof(DexterityAttribute), "0"),
        (nameof(DisarmTrapsAttribute), "0"),
        (nameof(UseDeviceAttribute), "0"),
        (nameof(SavingThrowAttribute), "0"),
        (nameof(StealthAttribute), "0"),
        (nameof(SearchAttribute), "0"),
    };
}
