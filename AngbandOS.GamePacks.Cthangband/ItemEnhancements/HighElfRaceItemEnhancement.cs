namespace AngbandOS.GamePacks.Cthangband;
    
[Serializable]
public class HighElfRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "5"),
        (nameof(ConstitutionAttribute), "1"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ValueAttribute), "14250"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "4"),
        (nameof(UseDeviceAttribute), "20"),
        (nameof(SavingThrowAttribute), "20"),
        (nameof(StealthAttribute), "4"),
        (nameof(SearchAttribute), "3"),
        (nameof(StrengthAttribute), "1")
    };
}
