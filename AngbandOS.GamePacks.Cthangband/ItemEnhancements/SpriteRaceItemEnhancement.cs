namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpriteRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-4"),
        (nameof(CharismaAttribute), "2"),
        (nameof(ConstitutionAttribute), "-2"),
        (nameof(WisdomAttribute), "3"),
        (nameof(IntelligenceAttribute), "3"),
        (nameof(DexterityAttribute), "3"),
        (nameof(ValueAttribute), "4500"),
        (nameof(InfravisionAttribute), "4"),
        (nameof(DisarmTrapsAttribute), "10"),
        (nameof(UseDeviceAttribute), "10"),
        (nameof(SavingThrowAttribute), "10"),
        (nameof(StealthAttribute), "4"),
        (nameof(SearchAttribute), "10"),
    };
}
