namespace AngbandOS.GamePacks.Cthangband;
public class HumanRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusStrengthAttribute), "0"),
        (nameof(BonusCharismaAttribute), "0"),
        (nameof(BonusConstitutionAttribute), "0"),
        (nameof(BonusWisdomAttribute), "0"),
        (nameof(BonusIntelligenceAttribute), "0"),
        (nameof(BonusDexterityAttribute), "0"),
        (nameof(DisarmTrapsAttribute), "0"),
        (nameof(UseDeviceAttribute), "0"),
        (nameof(SavingThrowAttribute), "0"),
        (nameof(StealthAttribute), "0"),
        (nameof(SearchAttribute), "0"),
        (nameof(UseDeviceAttribute), "0"),
    };
}
